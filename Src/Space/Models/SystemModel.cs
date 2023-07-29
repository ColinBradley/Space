namespace Space.Models;

using SpaceTraders.Api;
using SpaceTraders.Client;
using SpaceTraders.Model;
using System;

public class SystemModel
{
    private readonly Configuration mConfiguration;

    public event Action? Changed;

    public SystemModel(Configuration configuration, SpaceSystem spaceSystem)
    {
        this.SpaceSystem = new(spaceSystem);
        mConfiguration = configuration;

        this.SpaceSystem.Changed += _ => this.Changed?.Invoke();
        this.Waypoints.Changed += _ => this.Changed?.Invoke();
    }

    public Observable<SpaceSystem> SpaceSystem { get; }

    public ObservableCollection<Waypoint> Waypoints { get; } = new(Array.Empty<Waypoint>(), w => w.Symbol);

    public async Task Update()
    {
        await Task.WhenAll(
            this.UpdateSpaceSystem(),
            this.UpdateWaypoints()
        );
    }

    private async Task UpdateWaypoints()
    {
        this.Waypoints.SetValues(await GetWaypoints(mConfiguration, this.SpaceSystem.Value.Symbol));
    }

    private async Task UpdateSpaceSystem()
    {
        var system = await GetSystem(mConfiguration, this.SpaceSystem.Value.Symbol);

        if (system is not null)
        {
            this.SpaceSystem.Value = system;
        }
    }

    private static async Task<SpaceSystem> GetSystem(Configuration config, string symbol) =>
        (await new SystemsApi(config).GetSystemAsync(symbol)).Data;

    private static async Task<Waypoint[]> GetWaypoints(Configuration config, string symbol) =>
        (await new SystemsApi(config).GetSystemWaypointsAsync(symbol)).Data.ToArray();

    internal static async Task<SystemModel?> TryCreate(Configuration config, string symbol)
    {
        SpaceSystem system;
        try
        {
            system = await GetSystem(config, symbol);
        }
        catch (ApiException)
        {
            return null;
        }

        var model = new SystemModel(config, system);
        await model.UpdateWaypoints();

        return model;
    }

    public static string GetHumanName(WaypointType type) =>
        type switch
        {
            WaypointType.PLANET => "Planet",
            WaypointType.GASGIANT => "Gas Giant",
            WaypointType.MOON => "Moon",
            WaypointType.ORBITALSTATION => "Orbital Station",
            WaypointType.JUMPGATE => "Jump Gate",
            WaypointType.ASTEROIDFIELD => "Asteroid Field",
            WaypointType.NEBULA => "Nebula",
            WaypointType.DEBRISFIELD => "Debris Field",
            WaypointType.GRAVITYWELL => "Gravity Well",
            _ => throw new NotImplementedException(),
        };

    public static string GetHumanName(WaypointTrait.SymbolEnum symbol) =>
        symbol switch
        {
            WaypointTrait.SymbolEnum.UNCHARTED => "Uncharted",
            WaypointTrait.SymbolEnum.MARKETPLACE => "Marketplace",
            WaypointTrait.SymbolEnum.SHIPYARD => "Shipyard",
            WaypointTrait.SymbolEnum.OUTPOST => "Outpost",
            WaypointTrait.SymbolEnum.SCATTEREDSETTLEMENTS => "Scattered Settlements",
            WaypointTrait.SymbolEnum.SPRAWLINGCITIES => "Sprawling Cities",
            WaypointTrait.SymbolEnum.MEGASTRUCTURES => "Mega Structures",
            WaypointTrait.SymbolEnum.OVERCROWDED => "Overcrowded",
            WaypointTrait.SymbolEnum.HIGHTECH => "High Tech",
            WaypointTrait.SymbolEnum.CORRUPT => "Corrupt",
            WaypointTrait.SymbolEnum.BUREAUCRATIC => "Bureaucratic",
            WaypointTrait.SymbolEnum.TRADINGHUB => "Trading Hub",
            WaypointTrait.SymbolEnum.INDUSTRIAL => "Industrial",
            WaypointTrait.SymbolEnum.BLACKMARKET => "Black Market",
            WaypointTrait.SymbolEnum.RESEARCHFACILITY => "Research Facility",
            WaypointTrait.SymbolEnum.MILITARYBASE => "Military Base",
            WaypointTrait.SymbolEnum.SURVEILLANCEOUTPOST => "Surveillance Outpost",
            WaypointTrait.SymbolEnum.EXPLORATIONOUTPOST => "Exploration Outpost",
            WaypointTrait.SymbolEnum.MINERALDEPOSITS => "Mineral Deposits",
            WaypointTrait.SymbolEnum.COMMONMETALDEPOSITS => "Common Metal Deposits",
            WaypointTrait.SymbolEnum.PRECIOUSMETALDEPOSITS => "Precious Metal Deposits",
            WaypointTrait.SymbolEnum.RAREMETALDEPOSITS => "Rare Metal Deposits",
            WaypointTrait.SymbolEnum.METHANEPOOLS => "Methane Pools",
            WaypointTrait.SymbolEnum.ICECRYSTALS => "Ice Crystals",
            WaypointTrait.SymbolEnum.EXPLOSIVEGASES => "Explosive Gases",
            WaypointTrait.SymbolEnum.STRONGMAGNETOSPHERE => "Strong Magnetosphere",
            WaypointTrait.SymbolEnum.VIBRANTAURORAS => "Vibrant Auroras",
            WaypointTrait.SymbolEnum.SALTFLATS => "Salt Flats",
            WaypointTrait.SymbolEnum.CANYONS => "Canyons",
            WaypointTrait.SymbolEnum.PERPETUALDAYLIGHT => "Perpetual Daylight",
            WaypointTrait.SymbolEnum.PERPETUALOVERCAST => "Perpetual Overcast",
            WaypointTrait.SymbolEnum.DRYSEABEDS => "Dry Sea Beds",
            WaypointTrait.SymbolEnum.MAGMASEAS => "Magma Seas",
            WaypointTrait.SymbolEnum.SUPERVOLCANOES => "Super Volcanoes",
            WaypointTrait.SymbolEnum.ASHCLOUDS => "Ash Clouds",
            WaypointTrait.SymbolEnum.VASTRUINS => "Vast Ruins",
            WaypointTrait.SymbolEnum.MUTATEDFLORA => "Mutated Flora",
            WaypointTrait.SymbolEnum.TERRAFORMED => "Terraformed",
            WaypointTrait.SymbolEnum.EXTREMETEMPERATURES => "Extreme Temperatures",
            WaypointTrait.SymbolEnum.EXTREMEPRESSURE => "Extreme Pressure",
            WaypointTrait.SymbolEnum.DIVERSELIFE => "Diverse Life",
            WaypointTrait.SymbolEnum.SCARCELIFE => "Scarce Life",
            WaypointTrait.SymbolEnum.FOSSILS => "Fossils",
            WaypointTrait.SymbolEnum.WEAKGRAVITY => "Weak Gravity",
            WaypointTrait.SymbolEnum.STRONGGRAVITY => "Strong Gravity",
            WaypointTrait.SymbolEnum.CRUSHINGGRAVITY => "Crushing Gravity",
            WaypointTrait.SymbolEnum.TOXICATMOSPHERE => "Toxic Atmosphere",
            WaypointTrait.SymbolEnum.CORROSIVEATMOSPHERE => "Corrosive Atmosphere",
            WaypointTrait.SymbolEnum.BREATHABLEATMOSPHERE => "Breathable Atmosphere",
            WaypointTrait.SymbolEnum.JOVIAN => "Jovian",
            WaypointTrait.SymbolEnum.ROCKY => "Rocky",
            WaypointTrait.SymbolEnum.VOLCANIC => "Volcanic",
            WaypointTrait.SymbolEnum.FROZEN => "Frozen",
            WaypointTrait.SymbolEnum.SWAMP => "Swamp",
            WaypointTrait.SymbolEnum.BARREN => "Barren",
            WaypointTrait.SymbolEnum.TEMPERATE => "Temperate",
            WaypointTrait.SymbolEnum.JUNGLE => "Jungle",
            WaypointTrait.SymbolEnum.OCEAN => "Ocean",
            WaypointTrait.SymbolEnum.STRIPPED => "Stripped",
            _ => throw new NotImplementedException(),
        };
}
