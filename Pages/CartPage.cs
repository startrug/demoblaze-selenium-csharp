using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened()
        {
            Reporter.LogPassingTestStep("Cart page opened successfully");
            return IsElementDisplayedAfterWaiting(PlaceOrderButtonLocator);
        }

        internal bool IsProductAddedToCart(string productName)
        {
            Reporter.LogPassingTestStep($"Product \"{productName}\" added successfully to the cart");
            return IsElementDisplayedAfterWaiting(ProductNameInCartLocator(productName));
        }

        public void RemoveProductFromCart() => ClickOnElementAfterWaiting(DeleteProductLocator);

        public By ProductNameInCartLocator(string productName)
            => By.XPath($"//td[text()='{productName}']");

        internal bool IsProductRemovedFromCart(string productName)
        {
            Reporter.LogPassingTestStep($"Product \"{productName}\" removed successfully from the cart");
            return IsElementDisappearedAfterWaiting(ProductNameInCartLocator(productName));
        }

        internal bool IsTotalOrderVisible() => IsElementDisplayedImmediately(TotalPriceLocator);

        public OrderWindow PlaceOrder()
        {
            ClickOnElementAfterWaiting(PlaceOrderButtonLocator);
            Reporter.LogPassingTestStep($"Order was submitted");
            return new OrderWindow(Driver);
        }

        public By TotalPriceLocator => By.Id("totalp");
        public By DeleteProductLocator => By.CssSelector("[onclick^='deleteItem']");

        public int GetTotalPrice => int.Parse(GetTextOfElement(TotalPriceLocator));

        public By PlaceOrderButtonLocator => By.CssSelector(".btn-success");
    }
}