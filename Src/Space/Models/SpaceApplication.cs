namespace Space.Models;

using SpaceTraders.Api;
using SpaceTraders.Client;
using SpaceTraders.Model;

public class SpaceApplication
{
    private readonly Configuration mConfiguration;

    public event Action? Changed;

    public SpaceApplication(Configuration configuration)
    {
        mConfiguration = configuration;

        this.Agent.Changed += _ => this.Changed?.Invoke();
        this.Contracts.Changed += _ => this.Changed?.Invoke();
        this.AgentShips.Changed += _ => this.Changed?.Invoke();
    }

    public Observable<Agent?> Agent { get; } = new(null);

    public Observable<SpaceSystem?> VisibleSystem { get; } = new(null);

    public ObservableCollection<Waypoint> VisibleSystemWaypoints { get; } = new(Array.Empty<Waypoint>(), w => w.Symbol);

    public ObservableCollection<Contract> Contracts { get; } = new(Array.Empty<Contract>(), c => c.Id);

    public ObservableCollection<Ship> AgentShips { get; } = new(Array.Empty<Ship>(), s => s.Symbol);

    public async Task SetPlayerAccessToken(string token)
    {
        if (mConfiguration.AccessToken == token)
        {
            return;
        }

        mConfiguration.AccessToken = token;

        await Task.WhenAll(
            this.UpdateAgent(),
            this.UpdateContracts(),
            this.UpdateShips()
        );

        var commandShip = this.AgentShips.Values.First(s => s.Value.Registration.Role == ShipRole.COMMAND);
        await this.SetVisibleSystem(commandShip.Value.Nav.SystemSymbol);
    }

    private async Task SetVisibleSystem(string systemSymbol)
    {
        await Task.WhenAll(
            this.SetVisibleSystem_Core(systemSymbol),
            this.SetVisibleSystem_Waypoints(systemSymbol)
        );
    }

    private async Task SetVisibleSystem_Core(string systemSymbol) =>
        this.VisibleSystem.Value =
            (await new SystemsApi(mConfiguration)
                .GetSystemAsync(systemSymbol))
                    ?.Data;

    private async Task SetVisibleSystem_Waypoints(string systemSymbol) =>
        this.VisibleSystemWaypoints.SetValues(
            (await new SystemsApi(mConfiguration)
                .GetSystemWaypointsAsync(systemSymbol))
                    ?.Data.ToArray() ??
                    Array.Empty<Waypoint>());

    private async Task UpdateAgent()
    {
        this.Agent.Value =
            (await new AgentsApi(mConfiguration).GetMyAgentAsync())
                ?.Data;
    }

    private async Task UpdateShips()
    {
        this.AgentShips.SetValues(
            (await new FleetApi(mConfiguration).GetMyShipsAsync())
                ?.Data.ToArray() ??
                Array.Empty<Ship>());
    }

    private async Task UpdateContracts()
    {
        this.Contracts.SetValues(
            (await new ContractsApi(mConfiguration).GetContractsAsync())
                ?.Data.ToArray() ??
                Array.Empty<Contract>());
    }
}
