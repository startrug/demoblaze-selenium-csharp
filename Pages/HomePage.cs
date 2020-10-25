using System;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Models;
using demoblaze_selenium_csharp.Providers;
using OpenQA.Selenium;

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
        }

        internal bool IsPageOpened() => Driver.FindElement(HomeLinkLocator).Displayed;

        internal bool IsPageTitleCorrect() => Driver.Title.Equals(HomePageTitle);

        public ProductPage SelectProductAndOpenProductPage(Product product)
        {
            SelectCategory(product.Category);
            ClickOnElementAfterWaiting(ProductLocator(product.ProductName));

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
        private static Uri HomePageUrl => new Uri(ConfigurationProvider.Environment.ApplicationUrl);
    }
}