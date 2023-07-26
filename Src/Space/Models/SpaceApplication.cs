namespace Space.Models;

using SpaceTraders.Api;
using SpaceTraders.Model;

public class SpaceApplication
{
    public event Action? Changed;

    public SpaceApplication()
    {
        this.Agent.Changed += _ => this.Changed?.Invoke();
        this.Contracts.Changed += _ => this.Changed?.Invoke();
        this.Ships.Changed += _ => this.Changed?.Invoke();
    }

    public Observable<Agent?> Agent { get; } = new(null);

    public ObservableCollection<Contract> Contracts { get; } = new(Array.Empty<Contract>(), c => c.Id);

    public ObservableCollection<Ship> Ships { get; private set; } = new(Array.Empty<Ship>(), s => s.Symbol);

    public async Task SetPlayerAccessToken(string token)
    {
        if (token == SpaceTraders.Client.GlobalConfiguration.Instance.AccessToken)
        {
            return;
        }

        SpaceTraders.Client.GlobalConfiguration.Instance.AccessToken = token;

        await Task.WhenAll(
            this.UpdateAgent(),
            this.UpdateContracts(),
            this.UpdateShips()
        );
    }

    private async Task UpdateAgent()
    {
        this.Agent.Value = (await new AgentsApi().GetMyAgentAsync())?.Data;
    }

    private async Task UpdateShips()
    {
        this.Ships.SetValues(
            (await new FleetApi().GetMyShipsAsync())?.Data.ToArray() ??
            Array.Empty<Ship>());
    }

    private async Task UpdateContracts()
    {
        this.Contracts.SetValues(
            (await new ContractsApi().GetContractsAsync())?.Data.ToArray() ??
            Array.Empty<Contract>());
    }
}
