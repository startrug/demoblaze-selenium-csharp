using System;
using System.Globalization;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("OrderTests")]
    public class OrderTests : BaseTest<HomePage>
    {
        [SetUp]
        public void ResetTotalAmount()
        {
            CartPage.Reset();
        }

        [Test]
        public void GivenRequiredCustomerData_WhenCustomerFillsOutOrderForm_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            var cartPage = NavigationBar.ClickCartLink();

            Assert.IsTrue(cartPage.IsCartPageOpened());

            var orderWindow = cartPage.PlaceOrder();
            var purchaseAlert = orderWindow.FillOutFormAndPurchase(User);

            ValidatePurchaseAlertMessage(purchaseAlert);
        }

        [Test]
        public void GivenProductAndAllCustomerData_WhenCustomerAddsProductToCartFillsOutOrderFormAndConfirmsIt_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(Products[0]);
            productPage.AddProductToCart();

            Assert.IsTrue(productPage.IsProductAddedAlertShowed());

            var cartPage = NavigationBar.ClickCartLink();

            Assert.IsTrue(cartPage.IsProductAddedToCart(Products[0].ProductName));

            var orderWindow = cartPage.PlaceOrder();

            Assert.AreEqual(orderWindow.GetTotalAmountFromOrderWindow(), CartPage.TotalAmount);

            var purchaseAlert = orderWindow.FillOutFormAndPurchase(User);

            ValidatePurchaseAlertMessage(purchaseAlert);
        }

        [Test]
        public void WhenCustomerDidNotFillOutRequiredFildsOfOrderFormAndAcceptIt_ThenEnterRequiredDataAlertIsShowed()
        {
            var cartPage = NavigationBar.ClickCartLink();
            cartPage.CheckProductsTable();
            var orderWindow = cartPage.PlaceOrder();
            orderWindow.SubmitWindow();

            Assert.IsTrue(orderWindow.IsEnterRequiredDataAlertShowed());
        }

        protected override HomePage SelectTestedAppPage() => NavigationBar.ClickHomeLink();

        private void ValidatePurchaseAlertMessage(PurchaseAlert purchaseAlert)
        {
            var currentDate = DateTime.Today.AddMonths(-1).ToString("d/M/yyyy", CultureInfo.CreateSpecificCulture("en-US"));

            Assert.That(purchaseAlert.IsPurchaseAlertDisplayed(), Is.True);
            Assert.AreEqual(User.Name, purchaseAlert.GetPurchaseUserName());
            Assert.AreEqual(CartPage.TotalAmount + " USD", purchaseAlert.GetPurchaseTotalAmount());
            Assert.AreEqual(User.CreditCardNumber, purchaseAlert.GetPurchaseCreditCardNumber());
            Assert.AreEqual(currentDate, purchaseAlert.GetPurchaseDate());
        }
    }
}
