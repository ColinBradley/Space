namespace Space.Meta;

using SpaceTraders.Model;

public static class FactionMeta
{
    public static string GetHexColor(FactionSymbols? faction) =>
        faction switch
        {
            FactionSymbols.COSMIC => "#00BFFF77",
            FactionSymbols.VOID => "#FF8C0077",
            FactionSymbols.GALACTIC => "#32CD3277",
            FactionSymbols.QUANTUM => "#FFD70077",
            FactionSymbols.DOMINION => "#FF000077",
            FactionSymbols.ASTRO => "#A9A9A977",
            FactionSymbols.CORSAIRS => "#80008077",
            FactionSymbols.OBSIDIAN => "#00000077",
            FactionSymbols.AEGIS => "#8B451377",
            FactionSymbols.UNITED => "#F0E68C77",
            _ => "#FFF",
        };

    public static string[] GetSceneImagePaths(FactionSymbols? faction)
    {
        if (faction is null)
        {
            return Array.Empty<string>();
        }

        var imagePathBase = $"/images/factions/{faction.Value.ToString().ToLower()}/scenes/";
        try
        {
            return Directory.GetFiles("wwwroot/" + imagePathBase)
                .Select(p => imagePathBase + Path.GetFileName(p))
                .ToArray();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }

    public static string? GetLogoPath(FactionSymbols? faction)
    {
        if (faction is null)
        {
            return null;
        }

        var webPath = $"/images/factions/{faction.Value.ToString().ToLower()}/logo.jpg";
        if (File.Exists("wwwroot/" + webPath))
        {
            return webPath;
        }

        return null;
    }
}
