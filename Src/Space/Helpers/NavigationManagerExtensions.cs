namespace Space.Helpers;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

public static class NavigationManagerExtensions
{
    public static bool TryGetQueryString(this NavigationManager navManager, string key, out string value)
    {
        var uri = navManager.ToAbsoluteUri(navManager.Uri);
        var values = QueryHelpers.ParseQuery(uri.Query);

        if (values.TryGetValue(key, out var valueFromQueryString))
        {
            value = valueFromQueryString.ToString();
            return true;
        }

        value = string.Empty;
        return false;
    }
}
