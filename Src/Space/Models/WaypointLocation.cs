﻿namespace Space.Models;

using System;

public sealed class WaypointLocation
{
    public WaypointLocation(string symbol)
    {
        this.Symbol = symbol;

        var symbolParts = symbol.Split('-');
        if (symbolParts is [var sector, ..])
        {
            this.Sector = sector;
        }
        else
        {
            throw new ArgumentException($"Invalid waypoint symbol: {symbol}", nameof(symbol));
        }

        if (symbolParts is [_, var system, ..])
        {
            this.System = system;
        }

        if (symbolParts is [_, _, var waypoint])
        {
            this.Waypoint = waypoint;
        }
    }

    public string Symbol { get; }

    public string Sector { get; }

    public string System { get; } = string.Empty;

    public string Waypoint { get; } = string.Empty;

    public string SectorAndSystem => $"{this.Sector}-{this.System}";
}
