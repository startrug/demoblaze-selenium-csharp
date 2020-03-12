using System;
using System.Collections.Generic;
using demoblaze_selenium_csharp.Enum;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        public ProductPage ProductPage { get; set; }

        [Test, Order(6)]
        public void WhenUserOpensCartPage_ThenPageIsOpened()
        {
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsCartPageOpened(), Is.True);
        }

        [Test, Order(7)]
        public void GivenProductName_WhenUserAddProductToCart_ThenProductAddedSuccesfullyAlertShowedAndProductIsPresentInCart()
        {
            var productList = GnerateListOfProducts(NewMonitor, NewPhone);
            var totalPriceOfProducts = 0;

            foreach (var product in productList)
            {
                ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(product);
                totalPriceOfProducts += ProductPage.GetProductPrice();
                ProductPage.AddProductToCart();
                Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);
                CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
                Assert.That(CartPage.IsProductAddedToCart(product.ProductName), Is.True);
                Assert.That(totalPriceOfProducts == CartPage.GetTotalPrice, Is.True);
                DemoBlazeHomePage.GoTo();
            }
        }

        private static List<Product> GnerateListOfProducts(params Product[] products)
        {
            List<Product> productList = new List<Product>();
            foreach (var product in products)
            {
                productList.Add(product);
            }
            return productList;
        }
    }
}
