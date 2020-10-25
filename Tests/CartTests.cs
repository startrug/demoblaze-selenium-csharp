using System.Collections.Generic;
using System.Linq;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Models;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("CartTests")]
    public class CartTests : BaseTest<HomePage>
    {
        [SetUp]
        public void ResetTotalAmount()
        {
            CartPage.Reset();
        }

        [Test]
        public void WhenUserOpensCartPage_ThenPageIsOpened()
        {
            var cartPage = NavigationBar.ClickCartLink();

            Assert.IsTrue(cartPage.IsCartPageOpened());
        }

        [Test]
        public void GivenListOfProducts_WhenCustomerAddProductsToCart_ThenProductAddedSuccesfullyAlertShowedAndProductIsPresentInCartAndCorrectPriceIsDisplayed()
        {
            CartPage cartPage;
            var productList = GnerateListOfProducts(Products[0], Products[1]);

            foreach (var product in productList)
            {
                var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(product);
                productPage.AddProductToCart();

                Assert.IsTrue(productPage.IsProductAddedAlertShowed());

                cartPage = NavigationBar.ClickCartLink();

                Assert.IsTrue(cartPage.IsProductAddedToCart(product.ProductName));
                Assert.IsTrue(CartPage.TotalAmount == cartPage.GetTotalPrice);

                SelectTestedAppPage();
            }
        }

        [Test]
        public void GivenProduct_WhenCustomerAddsProductsToCartAndRemovesThem_ThenTotalOfTheOrderIsNotDisplayed()
        {
            var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(Products[2]);
            productPage.AddProductToCart();

            Assert.IsTrue(productPage.IsProductAddedAlertShowed());

            var cartPage = NavigationBar.ClickCartLink();

            Assert.IsTrue(cartPage.IsProductAddedToCart(Products[2].ProductName));

            cartPage.RemoveProductFromCart();

            Assert.IsTrue(cartPage.IsProductRemovedFromCart(Products[2].ProductName));
            Assert.IsFalse(cartPage.IsTotalOrderVisible());
        }

        [Test]
        public void GivenProduct_WhenCustomerAddsProductToCartAndConfirmsOrder_ThenOrderWindowIsDisplayed()
        {
            var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(Products[1]);
            productPage.AddProductToCart();

            Assert.IsTrue(productPage.IsProductAddedAlertShowed());

            var cartPage = NavigationBar.ClickCartLink();

            Assert.IsTrue(cartPage.IsProductAddedToCart(Products[1].ProductName));

            var orderWindow = cartPage.PlaceOrder();

            Assert.IsTrue(orderWindow.IsWindowOpened());
        }

        protected override HomePage SelectTestedAppPage() => NavigationBar.ClickHomeLink();

        private static List<Product> GnerateListOfProducts(params Product[] products)
            => products.Select(p => p).ToList();
    }
}
