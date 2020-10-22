using System;
using System.IO;
using Newtonsoft.Json;

namespace demoblaze_selenium_csharp.Providers
{
    public static class DataProvider
    {
        public static T Load<T>(string filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(AppDomain
                .CurrentDomain
                .BaseDirectory,
                $@"..\..\Data\{filename}.json")));
        }
    }
}
