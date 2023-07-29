namespace Space.Models;

using SpaceTraders.Api;
using SpaceTraders.Client;
using SpaceTraders.Model;
using System.Collections.Concurrent;

public class SpaceApplication
{
    private static Task<SpaceSystem[]>? sSystems = null;

    private readonly ConcurrentDictionary<string, SystemModel?> mSystemsBySymbol = new();

    private readonly Configuration mConfiguration;

    public event Action? Changed;

    public SpaceApplication(Configuration configuration)
    {
        mConfiguration = configuration;

        this.Agent.Changed += _ => this.Changed?.Invoke();
        this.Contracts.Changed += _ => this.Changed?.Invoke();
        this.Ships.Changed += _ => this.Changed?.Invoke();
    }

    public Observable<Agent?> Agent { get; } = new(null);

    public ObservableCollection<Contract> Contracts { get; } = new(Array.Empty<Contract>(), c => c.Id);

    public ObservableCollection<Ship> Ships { get; } = new(Array.Empty<Ship>(), s => s.Symbol);

    public IEnumerable<SystemModel> KnownSystems => mSystemsBySymbol.Values.Where(s => s is not null).Select(s => s!);

    public async Task SetPlayerAccessToken(string? token)
    {
        if (mConfiguration.AccessToken == token)
        {
            return;
        }

        mConfiguration.AccessToken = token;

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
            this.Contracts.SetValues(Array.Empty<Contract>());
            this.Ships.SetValues(Array.Empty<Ship>());

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

        system = await SystemModel.TryCreate(mConfiguration, symbol);
        mSystemsBySymbol.AddOrUpdate(symbol, system, (_, _) => system);

        this.Changed?.Invoke();

        return system;
    }

    public Task<SpaceSystem[]> GetSystems()
    {
        sSystems ??= FetchSystems(mConfiguration);

        return sSystems;
    }

    private async Task UpdateAgent()
    {
        try
        {
            this.Agent.Value =
                (await new AgentsApi(mConfiguration).GetMyAgentAsync())
                    ?.Data;
        }
        catch (ApiException ex) when (ex.ErrorCode == 401)
        {
            // Expired
            this.Agent.Value = null;
        }
    }

    private async Task UpdateShips()
    {
        this.Ships.SetValues(
            (await new FleetApi(mConfiguration).GetMyShipsAsync())
                ?.Data.ToArray() ??
                Array.Empty<Ship>());

        // Ensure that we're aware of each ship's system
        foreach (var ship in this.Ships.Values)
        {
            _ = await this.TryGetSystem(ship.Value.Nav.SystemSymbol);
        }
    }

    private async Task UpdateContracts()
    {
        this.Contracts.SetValues(
            (await new ContractsApi(mConfiguration).GetContractsAsync())
                ?.Data.ToArray() ??
                Array.Empty<Contract>());
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
