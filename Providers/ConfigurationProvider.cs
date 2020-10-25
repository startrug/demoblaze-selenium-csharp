using System;
using System.IO;
using demoblaze_selenium_csharp.Models;
using Newtonsoft.Json.Linq;

namespace demoblaze_selenium_csharp.Providers
{
    public class ConfigurationProvider
    {
        private const string WebDriverConfigSectionName = "webdriver";
        private const string EnvironmentConfigSectionName = "environment";
        private const string FilePath = @"..\..\TestSettings.json";
        private static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        public static WebDriverConfiguration WebDriver =>
            Load<WebDriverConfiguration>(WebDriverConfigSectionName);

        public static EnvironmentConfiguration Environment =>
            Load<EnvironmentConfiguration>(EnvironmentConfigSectionName);

        private static T Load<T>(string sectionName) =>
            JObject.Parse(File.ReadAllText(SettingsPath)).SelectToken(sectionName).ToObject<T>();
    }
}
