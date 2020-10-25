using demoblaze_selenium_csharp.Data;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened() => IsElementDisplayedAfterWaiting(AddToCartButtonlocator);

        public void AddProductToCart()
        {
            var productPrice = GetProductPrice();

            ClickOnElementAfterWaiting(AddToCartButtonlocator);
            WaitForBrowserAlert();

            CartPage.TotalAmount += productPrice;
        }

        public int GetProductPrice()
        {
            IsElementDisplayedAfterWaiting(ProductPriceLocator);
            string priceText = GetTextOfElement(ProductPriceLocator).Substring(1, 3);

            return int.Parse(priceText);
        }

        public bool IsProductAddedAlertShowed() => IsBrowserAlertShowed(AlertMessages.ProductAddedSuccesfully);

        public By AddToCartButtonlocator => By.CssSelector("[onclick^='addToCart']");

        public By ProductPriceLocator => By.CssSelector("h3.price-container");
    }
}