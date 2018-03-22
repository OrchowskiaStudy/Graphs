using Graphs.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Graphs.Views.Converters
{
    public static class LocalizationExtensions
    {
        private static Dictionary<string, ResourceManager> culturesResources = new Dictionary<string, ResourceManager>()
        {
            { "en-US", Assets.Locales.English.ResourceManager },
            { "pl-PL", Assets.Locales.Polish.ResourceManager }
        };

        public static List<string> GetSupportedLangs()
        {
            return culturesResources.Select(entry => entry.Key).ToList();
        }

        public static string Localize(this string key)
        {
            var cultureCode = LocalizationConfig.ActualCultureCode();
            culturesResources.TryGetValue(cultureCode, out ResourceManager dictionary);
            return dictionary?.GetString(key) ?? string.Empty;
        }
    }
}