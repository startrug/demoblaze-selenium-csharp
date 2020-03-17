using demoblaze_selenium_csharp.Enums;
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
        public void GivenListOfProducts_WhenCustomerAddProductsToCart_ThenProductAddedSuccesfullyAlertShowedAndProductIsPresentInCartAndCorrectPriceIsDisplayed()
        {
            var productList = GnerateListOfProducts(NewMonitor, NewPhone);

            foreach (var product in productList)
            {
                ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(product);
                TotalAmount += ProductPage.AddProductToCart();
                Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

                CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
                Assert.That(CartPage.IsProductAddedToCart(product.ProductName), Is.True);
                Assert.That(TotalAmount == CartPage.GetTotalPrice, Is.True);

                DemoBlazeHomePage.GoTo();
            }
        }

        [Test, Order(8)]
        public void GivenProduct_WhenCustomerAddsProductsToCartAndRemovesThem_ThenTotalOfTheOrderIsNotDisplayed()
        {
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(NewNotebook);

            TotalAmount = ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsProductAddedToCart(NewNotebook.ProductName), Is.True);

            CartPage.RemoveProductFromCart();
            Assert.That(CartPage.IsProductRemovedFromCart(NewNotebook.ProductName), Is.True);

            Assert.That(CartPage.IsTotalOrderVisible(), Is.False);
        }

        [Test, Order(9)]
        public void GivenProduct_WhenCustomerAddsProductToCartAndConfirmsOrder_ThenOrderWindowIsDisplayed()
        {
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(NewPhone);

            TotalAmount = ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsProductAddedToCart(NewPhone.ProductName), Is.True);

            OrderWindow = CartPage.PlaceOrder();
            Assert.That(OrderWindow.IsWindowOpened(), Is.True);
        }
    }
}
