using demoblaze_selenium_csharp.Enum;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class CartTests : CartBaseTest
    {
        [Test, Order(6)]
        public void WhenUserOpensCartPage_ThenPageIsOpened()
        {
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsCartPageOpened(), Is.True);
        }

        [Test, Order(7)]
        public void GivenListOfProducts_WhenUserAddProductsToCart_ThenProductAddedSuccesfullyAlertShowedAndProductIsPresentInCartAndCorrectPriceIsDisplayed()
        {
            var productList = GnerateListOfProducts(NewMonitor, NewPhone);

            foreach (var product in productList)
            {
                ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(product);
                TotalOrder += ProductPage.AddProductToCart();
                Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

                CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
                Assert.That(CartPage.IsProductAddedToCart(product.ProductName), Is.True);
                Assert.That(TotalOrder == CartPage.GetTotalPrice, Is.True);

                DemoBlazeHomePage.GoTo();
            }
        }

        [Test, Order(8)]
        public void GivenProduct_WhenUserAddsProductsToCartAndRemovesThem_ThenTotalOfTheOrderEqualsZero()
        {
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(NewNotebook);

            TotalOrder = ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsProductAddedToCart(NewNotebook.ProductName), Is.True);

            CartPage.RemoveProductFromCart();
            Assert.That(CartPage.IsProductRemovedFromCart(NewNotebook.ProductName), Is.True);

            Assert.That(CartPage.IsTotalOrderVisible(), Is.False);
        }

        [Test, Order(9)]
        public void GivenProduct_WhenUserAddsProductToCartAndConfirmsOrder_ThenOrderWindowDisplayed()
        {
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(NewPhone);

            TotalOrder = ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsProductAddedToCart(NewPhone.ProductName), Is.True);

            OrderWindow = CartPage.PlaceOrder();
            Assert.That(OrderWindow.IsWindowOpened(), Is.True);
        }
    }
}
