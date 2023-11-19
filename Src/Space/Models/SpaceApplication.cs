namespace Space.Models;

using SpaceTraders.Api;
using SpaceTraders.Client;
using SpaceTraders.Model;
using System.Collections.Concurrent;

public class SpaceApplication
{
    private static Task<SpaceSystem[]>? sSystems = null;

    private readonly ConcurrentDictionary<string, SystemModel?> mSystemsBySymbol = new();

    public event Action? Changed;

    public SpaceApplication(Configuration configuration)
    {
        this.Configuration = configuration;

        this.Agent.Changed += _ => this.Changed?.Invoke();
        this.Contracts.Changed += _ => this.Changed?.Invoke();
        this.Ships.Changed += _ => this.Changed?.Invoke();
        this.SelectedShip.Changed += _ => this.Changed?.Invoke();
        this.SelectedWaypoint.Changed += _ => this.Changed?.Invoke();
    }

    public Configuration Configuration { get; }

    public Observable<Agent?> Agent { get; } = new(null);

    public Observable<ShipModel?> SelectedShip { get; } = new(null);

    public Observable<Waypoint?> SelectedWaypoint { get; } = new(null);

    public ObservableCollection<Contract> Contracts { get; } = new([], c => c.Id);

    public ObservableCollection<ShipModel> Ships { get; } = new([], s => s.Ship.Symbol);

    public IEnumerable<SystemModel> KnownSystems => mSystemsBySymbol.Values.Where(s => s is not null).Select(s => s!);

    public async Task SetPlayerAccessToken(string? token)
    {
        if (this.Configuration.AccessToken == token)
        {
            return;
        }

        this.Configuration.AccessToken = token;

        if (string.IsNullOrEmpty(token))
        {
            this.Agent.Value = null;
        }
        else
        {
            await this.UpdateAgent();
        }

        if (this.Agent.Value is null)
        {
            this.Contracts.SetValues([]);
            this.Ships.SetValues([]);

            return;
        }

        await Task.WhenAll(
            this.UpdateContracts(),
            this.UpdateShips()
        );
    }

    public async Task<SystemModel?> TryGetSystem(string symbol)
    {
        if (mSystemsBySymbol.TryGetValue(symbol, out var system))
        {
            return system;
        }

        system = await SystemModel.TryCreate(this.Configuration, symbol);
        mSystemsBySymbol.AddOrUpdate(symbol, system, (_, _) => system);

        this.Changed?.Invoke();

        return system;
    }

    public async Task<bool> SetSelectedWaypoint(string symbol)
    {
        var waypoint = await this.GetWaypoint(symbol);
        if (waypoint is null)
        {
            return false;
        }

        this.SelectedWaypoint.Value = waypoint;

        return true;
    }

    public async Task<Waypoint?> GetWaypoint(string symbol)
    {
        var location = new WaypointLocation(symbol);
        var system = await this.TryGetSystem(location.SectorAndSystem);

        return system?.Waypoints.Values.FirstOrDefault(w => w.Value.Symbol == symbol)?.Value;
    }

    public Task<SpaceSystem[]> GetSystems()
    {
        // This can take like 2 mins to run so... yeah
        sSystems ??= FetchSystems(this.Configuration);

        return sSystems;
    }

    public async Task UpdateAgent()
    {
        try
        {
            this.Agent.Value =
                (await new AgentsApi(this.Configuration).GetMyAgentAsync())
                    ?.Data;
        }
        catch (ApiException ex) when (ex.ErrorCode == 401)
        {
            // Expired
            this.Agent.Value = null;
        }
    }

    public async Task UpdateShips()
    {
        this.Ships.SetValues(
            (await new FleetApi(this.Configuration).GetMyShipsAsync())
                ?.Data.Select(s => new ShipModel(s)).ToArray() ??
                []);

        // Ensure that we're aware of each ship's system
        foreach (var ship in this.Ships.Values)
        {
            _ = await this.TryGetSystem(ship.Value.Ship.Nav.SystemSymbol);
        }
    }

    public async Task UpdateContracts()
    {
        this.Contracts.SetValues(
            (await new ContractsApi(this.Configuration).GetContractsAsync())
                ?.Data.ToArray() ??
                []);
    }

    private static async Task<SpaceSystem[]> FetchSystems(Configuration configuration)
    {
        var systemsApi = new SystemsApi(configuration);
        var systemsInitialResult = await systemsApi.GetSystemsAsync(limit: 20);
        var systems = new List<SpaceSystem>(systemsInitialResult.Meta.Total);
        systems.AddRange(systemsInitialResult.Data);

        for (var page = systemsInitialResult.Meta.Page + 1; systems.Count < systemsInitialResult.Meta.Total; page++)
        {
            try
            {
                var result = await systemsApi.GetSystemsAsync(page, limit: systemsInitialResult.Meta.Limit);
                systems.AddRange(result.Data);
            }
            catch (ApiException ex) when (ex.ErrorCode == 429)
            {
                page--;

                // There's a limit of 2 a second
                await Task.Delay(1000);
            }
        }

        return systems.ToArray();
    }
}
