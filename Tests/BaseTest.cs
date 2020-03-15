using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using demoblaze_selenium_csharp.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demoblaze_selenium_csharp.Tests
{
    public class BaseTest
    {
        protected Product NewMonitor = new Product(Category.Monitors, "ASUS Full HD");
        protected Product NewPhone = new Product(Category.Phones, "Samsung galaxy s6");
        protected Product NewNotebook = new Product(Category.Laptops, "MacBook Pro");

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            TestCustomerData = new CustomerData(
                "anowak@poczta.pl",
                "Anna Nowak",
                "Sample message",
                "Test123!",
                "4551831919693310",
                "2",
                "2025",
                "Canada",
                "Vancouver");
            TestCustomerWithMissingData = new CustomerData("", "", "", "", "", "", "", "", "");

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            DemoBlazeHomePage = new HomePage(Driver);
            DemoBlazeHomePage.GoTo();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Driver.Close();
            Driver.Quit();
        }

        public IWebDriver Driver { get; private set; }
        public HomePage DemoBlazeHomePage { get; private set; }
        public ContactWindow ContactWindow { get; set; }
        public AboutUsWindow AboutUsWindow { get; set; }
        public CartPage CartPage { get; set; }
        public LogInWindow LogInWindow { get; set; }
        public SignUpWindow SignUpWindow { get; set; }
        public CustomerData TestCustomerData { get; private set; }
        public CustomerData TestCustomerWithMissingData { get; private set; }
        public LoggedInUserHomePage LoggedInUserHomePage { get; set; }
        public ProductPage ProductPage { get; set; }
        public OrderWindow OrderWindow { get; set; }
        public PurchaseAlert PurchaseAlert { get; set; }
        public int TotalOrder { get; set; } = 0;
    }
}