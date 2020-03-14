using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened() => IsElementDisplayedAfterWaiting(PlaceOrderButtonLocator);

        internal bool IsProductAddedToCart(string productName)
            => IsElementDisplayedAfterWaiting(ProductNameInCartLocator(productName));

        public void RemoveProductFromCart() => ClickOnElementAfterWaiting(DeleteProductLocator);

        public By ProductNameInCartLocator(string productName)
            => By.XPath($"//td[text()='{productName}']");

        internal bool IsProductRemovedFromCart(string productName)
            => IsElementDisappearedAfterWaiting(ProductNameInCartLocator(productName));

        internal bool IsTotalOrderVisible() => IsElementDisplayedImmediately(TotalPriceLocator);

        public OrderWindow PlaceOrder()
        {
            ClickOnElementAfterWaiting(PlaceOrderButtonLocator);
            return new OrderWindow(Driver);
        }

        public By TotalPriceLocator => By.Id("totalp");
        public By DeleteProductLocator => By.CssSelector("[onclick^='deleteItem']");

        public int GetTotalPrice => int.Parse(GetTextOfElement(TotalPriceLocator));

        public By PlaceOrderButtonLocator => By.CssSelector(".btn-success");
    }
}