using System;
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
            var productName = "ASUS Full HD";
            var totalPriceOfProducts = 0;
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(Category.Monitors, productName);

            totalPriceOfProducts += ProductPage.GetProductPrice();
            Console.WriteLine(ProductPage.GetProductPrice());
            ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed(), Is.True);

            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            Assert.That(CartPage.IsProductAddedToCart(productName), Is.True);
            Assert.That(totalPriceOfProducts == CartPage.TotalPrice, Is.True);
        }
    }
}
