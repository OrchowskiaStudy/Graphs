using System.Globalization;

namespace Graphs.Configuration
{
    public static class LocalizationConfig
    {
        public static void Configure(this CultureInfo culture, string localizationKey = "en-US")
        {
            CultureInfo myCulture = new CultureInfo(localizationKey);
            CultureInfo.CurrentCulture = myCulture;
            CultureInfo.CurrentUICulture = myCulture;
            CultureInfo.DefaultThreadCurrentCulture = myCulture;
            CultureInfo.DefaultThreadCurrentUICulture = myCulture;
        }

        public static CultureInfo ActualCulture()
        {
            return CultureInfo.CurrentCulture;
        }

        public static string ActualCultureCode()
        {
            return ActualCulture().Name;
        }
    }
}