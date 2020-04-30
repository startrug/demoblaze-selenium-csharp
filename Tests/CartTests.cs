using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("CartTests")]
    public class CartTests : CartAndOrderTestsBase
    {
        [Test]
        public void WhenUserOpensCartPage_ThenPageIsOpened()
        {
            var cartPage = NavigationBar.ClickCartLink();

            Assert.That(cartPage.IsCartPageOpened(), Is.True);
        }

        [Test, Order(7)]
        public void GivenListOfProducts_WhenCustomerAddProductsToCart_ThenProductAddedSuccesfullyAlertShowedAndProductIsPresentInCartAndCorrectPriceIsDisplayed()
        {
            var productList = GnerateListOfProducts(NewMonitor, NewPhone);
            CartPage cartPage;

            foreach (var product in productList)
            {
                var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(product);

                totalAmount += productPage.AddProductToCart();

                Assert.That(productPage.IsProductAddedAlertShowed(), Is.True);

                cartPage = NavigationBar.ClickCartLink();

                Assert.That(cartPage.IsProductAddedToCart(product.ProductName), Is.True);
                Assert.That(totalAmount == cartPage.GetTotalPrice, Is.True);

                SelectTestedAppPage();
            }
        }

        [Test]
        public void GivenProduct_WhenCustomerAddsProductsToCartAndRemovesThem_ThenTotalOfTheOrderIsNotDisplayed()
        {
            var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(NewNotebook);

            totalAmount = productPage.AddProductToCart();

            Assert.That(productPage.IsProductAddedAlertShowed(), Is.True);

            var cartPage = NavigationBar.ClickCartLink();

            Assert.That(cartPage.IsProductAddedToCart(NewNotebook.ProductName), Is.True);

            cartPage.RemoveProductFromCart();

            Assert.That(cartPage.IsProductRemovedFromCart(NewNotebook.ProductName), Is.True);
            Assert.That(cartPage.IsTotalOrderVisible(), Is.False);
        }

        [Test]
        public void GivenProduct_WhenCustomerAddsProductToCartAndConfirmsOrder_ThenOrderWindowIsDisplayed()
        {
            var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(NewPhone);

            totalAmount = productPage.AddProductToCart();

            Assert.That(productPage.IsProductAddedAlertShowed(), Is.True);

            var cartPage = NavigationBar.ClickCartLink();

            Assert.That(cartPage.IsProductAddedToCart(NewPhone.ProductName), Is.True);

            var orderWindow = cartPage.PlaceOrder();

            Assert.That(orderWindow.IsWindowOpened(), Is.True);
        }
    }
}
