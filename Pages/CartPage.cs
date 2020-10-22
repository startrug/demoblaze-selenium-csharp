using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        internal bool IsCartPageOpened() => Driver.FindElement(By.TagName("h2")).Displayed;

        public void CheckProductsTable()
        {
            string[] expectedHeaders = { "Pic", "Title", "Price", "x" };
            var i = 0;
            foreach (var item in Driver.FindElements(By.CssSelector("tr th")).Select(e => e.Text))
            {
                Assert.AreEqual(expectedHeaders[i], item);
                i++;
            }
        }

        public bool IsProductAddedToCart(string productName) => IsElementDisplayedAfterWaiting(ProductNameInCartLocator(productName));

        public void RemoveProductFromCart() => ClickOnElementAfterWaiting(DeleteProductLocator);

        public By ProductNameInCartLocator(string productName)
            => By.XPath($"//td[text()='{productName}']");

        public bool IsProductRemovedFromCart(string productName) => IsElementDisappearedAfterWaiting(ProductNameInCartLocator(productName));

        public bool IsTotalOrderVisible() => IsElementDisplayedImmediately(TotalPriceLocator);

        public OrderWindow PlaceOrder()
        {
            Click(PlaceOrderButtonLocator);

            return new OrderWindow(Driver);
        }

        public static void Reset()
        {
            TotalAmount = 0;
        }

        public By TotalPriceLocator => By.Id("totalp");
        public By DeleteProductLocator => By.CssSelector("[onclick^='deleteItem']");

        public int GetTotalPrice => int.Parse(GetTextOfElement(TotalPriceLocator));

        public By PlaceOrderButtonLocator => By.CssSelector("[data-target='#orderModal']");

        public static int TotalAmount { get; set; }
    }
}