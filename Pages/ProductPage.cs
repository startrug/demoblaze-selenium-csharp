using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public int AddProductToCart()
        {
            var productPrice = GetProductPrice();
            ClickOnElementAfterWaiting(AddToCartButtonlocator);
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

        public bool IsProductAddedAlertShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(ProductAddedSuccesfullyAlert);

        public By AddToCartButtonlocator => By.CssSelector("[onclick^='addToCart']");

        public string ProductAddedSuccesfullyAlert => "Product added";

        public By ProductPriceLocator => By.CssSelector("h3.price-container");
    }
}