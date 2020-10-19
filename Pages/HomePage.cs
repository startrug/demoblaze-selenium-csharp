using System;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(HomePageUrl);
            Reporter.LogPassingTestStep($"Opening demoblaze.com homepage");
        }

        internal bool IsPageOpened()
        {
            var testStepResult = Driver.FindElement(HomeLinkLocator).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("Homepage");

            return testStepResult;
        }

        internal bool IsPageTitleCorrect()
        {
            var testStepResult = Driver.Title == HomePageTitle;
            Reporter.LogTestStep(
                testStepResult,
                "Page title is correct",
                $"Expected page title was {HomePageTitle} but actual page title is: {Driver.Title}"
                );

            return testStepResult;
        }

        public ProductPage SelectProductAndOpenProductPage(Product product)
        {
            SelectCategory(product.Category);
            Reporter.LogPassingTestStep($"Category \"{product.Category}\" has been selected");
            ClickOnElementAfterWaiting(ProductLocator(product.ProductName));
            Reporter.LogPassingTestStep($"Product \"{product.ProductName}\" has been selected");

            return new ProductPage(Driver);
        }

        private void SelectCategory(Category category)
        {
            switch (category)
            {
                case Category.Phones:
                    Click(PhonesCategoryLocator);
                    break;
                case Category.Laptops:
                    Click(LaptopsCategoryLocator);
                    break;
                case Category.Monitors:
                    Click(MonitorsCategoryLocator);
                    break;
                default:
                    throw new Exception("No such product category");
            }
        }

        private By ProductLocator(string productName) => By.XPath($"//a[text()='{productName}']");

        private By PhonesCategoryLocator => By.CssSelector("[onclick=\"byCat('phone')\"]");
        private By LaptopsCategoryLocator => By.CssSelector("[onclick=\"byCat('notebook')\"]");
        private By MonitorsCategoryLocator => By.CssSelector("[onclick=\"byCat('monitor')\"]");

        public Slider Slider { get; private set; }

        private const string HomePageTitle = "STORE";
        private const string HomePageUrl = "https://www.demoblaze.com/index.html";
    }
}