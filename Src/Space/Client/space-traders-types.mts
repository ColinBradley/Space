
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
    UNCHARTED = 1,
    MARKETPLACE = 2,
    SHIPYARD = 3,
    OUTPOST = 4,
    SCATTEREDSETTLEMENTS = 5,
    SPRAWLINGCITIES = 6,
    MEGASTRUCTURES = 7,
    OVERCROWDED = 8,
    HIGHTECH = 9,
    CORRUPT = 10,
    BUREAUCRATIC = 11,
    TRADINGHUB = 12,
    INDUSTRIAL = 13,
    BLACKMARKET = 14,
    RESEARCHFACILITY = 15,
    MILITARYBASE = 16,
    SURVEILLANCEOUTPOST = 17,
    EXPLORATIONOUTPOST = 18,
    MINERALDEPOSITS = 19,
    COMMONMETALDEPOSITS = 20,
    PRECIOUSMETALDEPOSITS = 21,
    RAREMETALDEPOSITS = 22,
    METHANEPOOLS = 23,
    ICECRYSTALS = 24,
    EXPLOSIVEGASES = 25,
    STRONGMAGNETOSPHERE = 26,
    VIBRANTAURORAS = 27,
    SALTFLATS = 28,
    CANYONS = 29,
    PERPETUALDAYLIGHT = 30,
    PERPETUALOVERCAST = 31,
    DRYSEABEDS = 32,
    MAGMASEAS = 33,
    SUPERVOLCANOES = 34,
    ASHCLOUDS = 35,
    VASTRUINS = 36,
    MUTATEDFLORA = 37,
    TERRAFORMED = 38,
    EXTREMETEMPERATURES = 39,
    EXTREMEPRESSURE = 40,
    DIVERSELIFE = 41,
    SCARCELIFE = 42,
    FOSSILS = 43,
    WEAKGRAVITY = 44,
    STRONGGRAVITY = 45,
    CRUSHINGGRAVITY = 46,
    TOXICATMOSPHERE = 47,
    CORROSIVEATMOSPHERE = 48,
    BREATHABLEATMOSPHERE = 49,
    JOVIAN = 50,
    ROCKY = 51,
    VOLCANIC = 52,
    FROZEN = 53,
    SWAMP = 54,
    BARREN = 55,
    TEMPERATE = 56,
    JUNGLE = 57,
    OCEAN = 58,
    STRIPPED = 59
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
    NEUTRONSTAR = 1,
    REDSTAR = 2,
    ORANGESTAR = 3,
    BLUESTAR = 4,
    YOUNGSTAR = 5,
    WHITEDWARF = 6,
    BLACKHOLE = 7,
    HYPERGIANT = 8,
    NEBULA = 9,
    UNSTABLE = 10
}

export enum WaypointType {
    PLANET = 1,
    GASGIANT = 2,
    MOON = 3,
    ORBITALSTATION = 4,
    JUMPGATE = 5,
    ASTEROIDFIELD = 6,
    NEBULA = 7,
    DEBRISFIELD = 8,
    GRAVITYWELL = 9
}
