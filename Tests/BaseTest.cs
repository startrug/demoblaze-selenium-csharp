using System;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using demoblaze_selenium_csharp.Resources;
using demoblaze_selenium_csharp.Values;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Tests
{
    public abstract class BaseTest<TTestedAppPage>
    {
        public IWebDriver Driver { get; private set; }
        public HomePage DemoBlazeHomePage { get; private set; }

        public User TestUser { get; private set; }
        public User TestUserWithMissingData { get; private set; }

        [OneTimeSetUp]
        public void SetupBeforeAllTests()
        {
            Reporter.StartReporter();
        }

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            TestUser = new User
            {
                Email = "anowak@poczta.pl",
                Name = "Anna Nowak",
                Message = "Sample message",
                Password = "Test123!",
                CreditCardNumber = "4551831919693310",
                ExpirationMonth = "2",
                ExpirationYear = "2025",
                Country = "Canada",
                City = "Vancouver"
            };

            TestUserWithMissingData = new User
            {
                Name = "",
                Password = "",
            };

            Logger.Debug("*** TEST STARTED ***");
            Reporter.AddTestCaseMetadataToHtmlReports(TestContext.CurrentContext);

            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            ScreenshotTaker = new ScreenshotTaker(Driver);
            DemoBlazeHomePage = new HomePage(Driver);
            NavigationBar = new NavigationBar(Driver);

            DemoBlazeHomePage.GoTo();
            TestedPageOrWindow = SelectTestedAppPage();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");

            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.CurrentContext.Test.Name);
                Logger.Debug("*** TEST STOPPED ***");
            }
        }

        protected abstract TTestedAppPage SelectTestedAppPage();

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

        protected TTestedAppPage TestedPageOrWindow { get; set; }

        protected NavigationBar NavigationBar { get; set; }

        private ScreenshotTaker ScreenshotTaker { get; set; }

        protected Product NewMonitor = new Product(Category.Monitors, "ASUS Full HD");
        protected Product NewPhone = new Product(Category.Phones, "Samsung galaxy s6");
        protected Product NewNotebook = new Product(Category.Laptops, "MacBook Pro");

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}