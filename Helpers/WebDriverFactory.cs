using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace demoblaze_selenium_csharp.Helpers
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserName browserName)
        {
            switch (browserName)
            {
                case BrowserName.Chrome:
                    return GetChromeDriver();
                case BrowserName.Firefox:
                    return GetFirefoxDriver();
                case BrowserName.Edge:
                    return GetEdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exist");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArguments("start-maximized");
            options.AddArguments("--disable-extensions");

            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryWithChromeDriver = CreateFilePath(outputDirectory);

            if (string.IsNullOrEmpty(directoryWithChromeDriver))
            {
                directoryWithChromeDriver = CreateFilePath(outputDirectory);
            }

            return new ChromeDriver(directoryWithChromeDriver, options);
        }

        private IWebDriver GetFirefoxDriver()
        {
            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryWithFirefoxDriver = CreateFilePath(outputDirectory);

            if (string.IsNullOrEmpty(directoryWithFirefoxDriver))
            {
                directoryWithFirefoxDriver = CreateFilePath(outputDirectory);
            }

            return new FirefoxDriver(directoryWithFirefoxDriver);
        }

        private IWebDriver GetEdgeDriver()
        {
            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryWithEdgeDriver = CreateFilePath(outputDirectory);

            if (string.IsNullOrEmpty(directoryWithEdgeDriver))
            {
                directoryWithEdgeDriver = CreateFilePath(outputDirectory);
            }

            return new EdgeDriver(directoryWithEdgeDriver);
        }
        private static string CreateFilePath(string outputDirectory)
            => Path.GetFullPath(Path.Combine(outputDirectory ?? throw new InvalidOperationException(), @"..\..\..\demoblaze-selenium-csharp\bin\Debug"));

        private static string GetAssemblysOutputDirectory() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
