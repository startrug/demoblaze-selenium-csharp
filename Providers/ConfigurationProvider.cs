using System;
using System.Configuration;
using System.IO;
using demoblaze_selenium_csharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace demoblaze_selenium_csharp.Providers
{
    public class ConfigurationProvider
    {
        private const string WebDriverConfigSectionName = "webdriver";
        private const string EnvironmentConfigSectionName = "environment";
        private static readonly string SettingsPath = Path.Combine(AppDomain
                        .CurrentDomain
                        .BaseDirectory,
                        $@"..\..\TestSettings.json");

        public static WebDriverConfiguration WebDriver =>
            Load<WebDriverConfiguration>(WebDriverConfigSectionName);

        public static EnvironmentConfiguration Environment =>
            Load<EnvironmentConfiguration>(EnvironmentConfigSectionName);

        private static T Load<T>(string sectionName)
        {
            var json = File.ReadAllText(SettingsPath);
            return JObject.Parse(json).SelectToken(sectionName).ToObject<T>();
            //return JsonConvert.DeserializeObject<T>();
        }

        public static WebDriverConfiguration LoadDriverConfig()
        {
            return (WebDriverConfiguration)ConfigurationManager.GetSection(WebDriverConfigSectionName);
        }
    }
}
