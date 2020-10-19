using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using demoblaze_selenium_csharp.Resources;
using demoblaze_selenium_csharp.Values;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public abstract class BaseTest<TTestedAppPage>
    {
        public IWebDriver Driver { get; private set; }
        public HomePage DemoBlazeHomePage { get; private set; }

        public User TestUser { get; private set; }
        public User TestUserWithMissingData { get; private set; }

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

            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            DemoBlazeHomePage = new HomePage(Driver);
            NavigationBar = new NavigationBar(Driver);

            DemoBlazeHomePage.GoTo();
            TestedPageOrWindow = SelectTestedAppPage();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Driver.Close();
        }

        protected abstract TTestedAppPage SelectTestedAppPage();

        protected TTestedAppPage TestedPageOrWindow { get; set; }
        protected NavigationBar NavigationBar { get; set; }

        protected Product NewMonitor = new Product(Category.Monitors, "ASUS Full HD");
        protected Product NewPhone = new Product(Category.Phones, "Samsung galaxy s6");
        protected Product NewNotebook = new Product(Category.Laptops, "MacBook Pro");
    }
}