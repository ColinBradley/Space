
export interface SpaceSystem {
    type: SystemType;
    symbol: string;
    sectorSymbol: string;
    x: number;
    y: number;
    waypoints: SystemWaypoint[];
    factions: Faction[];
}

export interface SystemWaypoint {
    type: WaypointType;
    symbol: string;
    x: number;
    y: number;
}

export interface Waypoint {
    type: WaypointType;
    symbol: string;
    systemSymbol: string;
    orbitals: WaypointOrbital[];
    faction: Faction;
    traits: WaypointTrait[];
    chart: Chart;
    x: number;
    y: number;
}

export interface Chart {
    waypointSymbol: string;
    submittedBy: string;
    submittedOn: string;
}

export interface WaypointTrait {
    symbol: WaypointTraitSymbol;
    name: string;
    description: string;
}

export enum WaypointTraitSymbol {
    Uncharted = 1,
    Marketplace = 2,
    Shipyard = 3,
    Outpost = 4,
    ScatteredSettlements = 5,
    SprawlingCities = 6,
    MegaStructures = 7,
    Overcrowded = 8,
    HighTech = 9,
    Corrupt = 10,
    Bureaucratic = 11,
    TradingHub = 12,
    Industrial = 13,
    BlackMarket = 14,
    ResearchFacility = 15,
    MilitaryBase = 16,
    SurveillanceOutpost = 17,
    ExplorationOutpost = 18,
    MineralDeposits = 19,
    CommonMetalDeposits = 20,
    PreciousMetalDeposits = 21,
    RareMetalDeposits = 22,
    MethanePools = 23,
    IceCrystals = 24,
    ExplosiveGases = 25,
    StrongMagnetosphere = 26,
    VibrantAuroras = 27,
    SaltFlats = 28,
    Canyons = 29,
    PerpetualDaylight = 30,
    PerpetualOvercast = 31,
    DrySeaBeds = 32,
    MagmaSeas = 33,
    SuperVolcanoes = 34,
    AshClouds = 35,
    VastRuins = 36,
    MutatedFlora = 37,
    Terraformed = 38,
    ExtremeTemperatures = 39,
    ExtremePressure = 40,
    DiverseLife = 41,
    ScarceLife = 42,
    Fossils = 43,
    WeakGravity = 44,
    StrongGravity = 45,
    CrushingGravity = 46,
    ToxicAtmosphere = 47,
    CorrosiveAtmosphere = 48,
    BreathableAtmosphere = 49,
    Jovian = 50,
    Rocky = 51,
    Volcanic = 52,
    Frozen = 53,
    Swamp = 54,
    Barren = 55,
    Temperate = 56,
    Jungle = 57,
    Ocean = 58,
    Stripped = 59
}

export interface WaypointOrbital {
    symbol: string;
}

export interface Faction {
    symbol: FactionSymbol;
}

export enum FactionSymbol {
    COSMIC = 1,
    VOID = 2,
    GALACTIC = 3,
    QUANTUM = 4,
    DOMINION = 5,
    ASTRO = 6,
    CORSAIRS = 7,
    OBSIDIAN = 8,
    AEGIS = 9,
    UNITED = 10,
    SOLITARY = 11,
    COBALT = 12,
    OMEGA = 13,
    ECHO = 14,
    LORDS = 15,
    CULT = 16,
    ANCIENTS = 17,
    SHADOW = 18,
    ETHEREAL = 19
}

export enum SystemType {
    NeutronStar = 1,
    RedStar = 2,
    OrangeStar = 3,
    BlueStar = 4,
    YoungStar = 5,
    WhiteDwarf = 6,
    BlackHole = 7,
    HyperGiant = 8,
    Nebula = 9,
    Unstable = 10
}

export enum WaypointType {
    Planet = 1,
    GasGiant = 2,
    Moon = 3,
    OrbitalStation = 4,
    JumpGate = 5,
    AsteroidField = 6,
    Nebula = 7,
    DebrisField = 8,
    GravityWell = 9
}
