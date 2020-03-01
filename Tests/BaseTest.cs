using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demoblaze_selenium_csharp.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }
        public DemoBlazeHomePage DemoBlazeHomePage { get; private set; }
        public ContactPage ContactPage { get; set; }
        public AboutUsPage AboutUsPage { get; set; }
        public CartPage CartPage { get; set; }

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            DemoBlazeHomePage = new DemoBlazeHomePage(Driver);
            DemoBlazeHomePage.GoTo();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}