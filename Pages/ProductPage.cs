using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public void AddProductToCart()
        {
            WaitForElementAndClickOnIt(AddToCartButtonlocator);
            GetProductPrice();
            WaitForBrowserAlert();
        }

        public int GetProductPrice()
        {
            WaitForElementVisibility(ProductPriceLocator);
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