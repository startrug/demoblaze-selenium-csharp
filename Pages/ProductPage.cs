using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened()
        {
            var testStepResult = IsElementDisplayedAfterWaiting(AddToCartButtonlocator);
            LoggerHelpers.LogInfoAboutPageOrWindowOpened(testStepResult, "Product page");

            return testStepResult;
        }

        public int AddProductToCart()
        {
            var productPrice = GetProductPrice();
            ClickOnElementAfterWaiting(AddToCartButtonlocator);
            Reporter.LogPassingTestStep("Adding selected product to the cart");
            WaitForBrowserAlert();
            Reporter.LogPassingTestStep($"Selected product price is ${productPrice}");

            return productPrice;
        }

        public int GetProductPrice()
        {
            IsElementDisplayedAfterWaiting(ProductPriceLocator);
            string priceText = GetTextOfElement(ProductPriceLocator).Substring(1, 3);

            return int.Parse(priceText);
        }

        public bool IsProductAddedAlertShowed() => IsBrowserAlertShowed(AlertType.ProductAddedSuccesfullyAlert);

        public By AddToCartButtonlocator => By.CssSelector("[onclick^='addToCart']");

        public By ProductPriceLocator => By.CssSelector("h3.price-container");
    }
}