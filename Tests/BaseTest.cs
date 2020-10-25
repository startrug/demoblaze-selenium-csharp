using System.Collections.Generic;
using System.IO;
using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Models;
using demoblaze_selenium_csharp.Pages;
using demoblaze_selenium_csharp.Providers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public abstract class BaseTest<TTestedAppPage>
    {
        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            User = DataProvider.Load<User>("User");
            Products = DataProvider.Load<List<Product>>("Products");

            var driverConfig = ConfigurationProvider.WebDriver;
            var logger = new Logger("logger", InternalTraceLevel.Info, TextWriter.Null);
            driver = new WebDriverFactory().GetWebDriver(driverConfig, logger);
            demoBlazeHomePage = new HomePage(driver);
            NavigationBar = new NavigationBar(driver);

            demoBlazeHomePage.GoTo();
            TestedPageOrWindow = SelectTestedAppPage();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            driver.Quit();
        }

        protected abstract TTestedAppPage SelectTestedAppPage();

        protected TTestedAppPage TestedPageOrWindow { get; set; }
        protected NavigationBar NavigationBar { get; set; }
        protected User User { get; private set; }
        protected List<Product> Products { get; private set; }

        private IWebDriver driver;
        private HomePage demoBlazeHomePage;
    }
}