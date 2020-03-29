using demoblaze_selenium_csharp.Helpers;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened()
        {
            var testStepResult = IsElementDisplayedAfterWaiting(PlaceOrderButtonLocator);
            LoggerHelpers.LogInfoAboutPageOrWindowOpened(testStepResult, "Cart page");
            return testStepResult;
        }

        internal bool IsProductAddedToCart(string productName)
        {
            var testStepResult = IsElementDisplayedAfterWaiting(ProductNameInCartLocator(productName));
            LoggerHelpers.LogInfoAboutProductAddedToCart(testStepResult, productName);
            return testStepResult;
        }

        public void RemoveProductFromCart() => ClickOnElementAfterWaiting(DeleteProductLocator);

        public By ProductNameInCartLocator(string productName)
            => By.XPath($"//td[text()='{productName}']");

        internal bool IsProductRemovedFromCart(string productName)
        {
            var testStepResult = IsElementDisappearedAfterWaiting(ProductNameInCartLocator(productName));
            LoggerHelpers.LogInfoAboutProductRemovedFromCart(testStepResult, productName);
            return testStepResult;
        }

        internal bool IsTotalOrderVisible() => IsElementDisplayedImmediately(TotalPriceLocator);

        public OrderWindow PlaceOrder()
        {
            ClickOnElementAfterWaiting(PlaceOrderButtonLocator);
            Reporter.LogPassingTestStep($"The \"Place Order\" button has been clicked");
            return new OrderWindow(Driver);
        }

        public By TotalPriceLocator => By.Id("totalp");
        public By DeleteProductLocator => By.CssSelector("[onclick^='deleteItem']");

        public int GetTotalPrice => int.Parse(GetTextOfElement(TotalPriceLocator));

        public By PlaceOrderButtonLocator => By.CssSelector(".btn-success");
    }
}