using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        public By PlaceOrderButton => By.XPath("//button[text()='Place Order']");

        internal bool IsCartPageOpened() => WaitForElement(PlaceOrderButton).Displayed;
    }
}