using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened() => WaitForElementVisibility(PlaceOrderButton);

        internal bool IsProductAddedToCart(string productName)
            => WaitForElementVisibility(ProductNameInCartLocator(productName));

        public void RemoveProductFromCart() => WaitForElementAndClickOnIt(DeleteProductLocator);

        public By ProductNameInCartLocator(string productName)
            => By.XPath($"//td[text()='{productName}']");

        internal bool IsProductRemovedFromCart(string productName)
            => WaitForElementDisappear(ProductNameInCartLocator(productName));

        internal bool IsTotalOrderVisible() => IsElementDisplayed(TotalPriceLocator);

        public OrderWindow PlaceOrder()
        {
            WaitForElementAndClickOnIt(PlaceOrderButton);
            return new OrderWindow(Driver);
        }

        public By TotalPriceLocator => By.Id("totalp");
        public By DeleteProductLocator => By.CssSelector("[onclick^='deleteItem']");

        public int GetTotalPrice => int.Parse(GetTextOfElement(TotalPriceLocator));

        public By PlaceOrderButton => By.CssSelector(".btn-success");
    }
}