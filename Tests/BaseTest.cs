using System;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using demoblaze_selenium_csharp.Resources;
using demoblaze_selenium_csharp.Values;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Tests
{
    public class BaseTest
    {
        protected Product NewMonitor = new Product(Category.Monitors, "ASUS Full HD");
        protected Product NewPhone = new Product(Category.Phones, "Samsung galaxy s6");
        protected Product NewNotebook = new Product(Category.Laptops, "MacBook Pro");

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
            //Driver.Manage().Window.Maximize();
            ScreenshotTaker = new ScreenshotTaker(Driver);

            DemoBlazeHomePage = new HomePage(Driver);
            DemoBlazeHomePage.GoTo();
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

        public IWebDriver Driver { get; private set; }
        public HomePage DemoBlazeHomePage { get; private set; }
        public ContactWindow ContactWindow { get; set; }
        public AboutUsWindow AboutUsWindow { get; set; }
        public CartPage CartPage { get; set; }
        public LogInWindow LogInWindow { get; set; }
        public SignUpWindow SignUpWindow { get; set; }
        public User TestUser { get; private set; }
        public User TestUserWithMissingData { get; private set; }
        public LoggedInUserHomePage LoggedInUserHomePage { get; set; }
        public ProductPage ProductPage { get; set; }
        public OrderWindow OrderWindow { get; set; }
        public PurchaseAlert PurchaseAlert { get; set; }
        public int TotalAmount { get; set; } = 0;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }
    }
}