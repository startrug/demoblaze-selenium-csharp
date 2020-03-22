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
            Reporter.LogTestStep(
                testStepResult,
                "Cart page has been opened successfully",
                "Cart page has not been opened"
                );
            return testStepResult;
        }

        internal bool IsProductAddedToCart(string productName)
        {
            var testStepResult = IsElementDisplayedAfterWaiting(ProductNameInCartLocator(productName));
            Reporter.LogTestStep(
                testStepResult,
                $"Product \"{productName}\" has been added successfully to the cart",
                $"Product \"{productName}\" has not been added to the cart"
                );
            return testStepResult;
        }

        public void RemoveProductFromCart() => ClickOnElementAfterWaiting(DeleteProductLocator);

        public By ProductNameInCartLocator(string productName)
            => By.XPath($"//td[text()='{productName}']");

        internal bool IsProductRemovedFromCart(string productName)
        {
            var testStepResult = IsElementDisappearedAfterWaiting(ProductNameInCartLocator(productName));
            Reporter.LogTestStep(
                testStepResult,
                $"Product \"{productName}\" has been removed successfully from the cart",
                $"Product \"{productName}\" has not been removed from the cart"
                );
            return testStepResult;
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