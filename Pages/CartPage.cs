using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened() => WaitForElementVisibility(PlaceOrderButton);

        internal bool IsProductAddedToCart(string productName)
        {
            WaitForElementVisibility(ProductNameInCartLocator);
            return GetTextOfElement(ProductNameInCartLocator) == productName;
        }
        public int TotalPrice => int.Parse(GetTextOfElement(TotalPriceLocator));

        public By PlaceOrderButton => By.XPath("//button[text()='Place Order']");

        public By ProductNameInCartLocator => By.CssSelector("td:nth-child(2)");
        public By TotalPriceLocator => By.CssSelector("td:nth-child(3)");


    }
}