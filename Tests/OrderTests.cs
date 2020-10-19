using System;
using System.Globalization;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("OrderTests")]
    public class OrderTests : CartAndOrderTestsBase
    {
        [Test]
        public void GivenRequiredCustomerData_WhenCustomerFillsOutOrderForm_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            var orderWindow = ClickPlaceOrder();
            var purchaseAlert = orderWindow.FillOutFormAndPurchase(TestUser);

            ValidatePurchaseAlertMessage(purchaseAlert);
        }

        [Test]
        public void GivenProductAndAllCustomerData_WhenCustomerAddsProductToCartFillsOutOrderFormAndConfirmsIt_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            var productPage = TestedPageOrWindow.SelectProductAndOpenProductPage(NewMonitor);

            totalAmount = productPage.AddProductToCart();

            Assert.That(productPage.IsProductAddedAlertShowed, Is.True);

            var orderWindow = ClickPlaceOrder();

            Assert.That(orderWindow.GetTotalAmountFromOrderWindow() == totalAmount, Is.True);

            var purchaseAlert = orderWindow.FillOutFormAndPurchase(TestUser);

            ValidatePurchaseAlertMessage(purchaseAlert);
        }

        [Test]
        public void WhenCustomerDidNotFillOutRequiredFildsOfOrderFormAndAcceptIt_ThenEnterRequiredDataAlertIsShowed()
        {
            var orderWindow = ClickPlaceOrder();
            orderWindow.SubmitWindow();

            Assert.That(orderWindow.IsEnterRequiredDataAlertShowed(), Is.True);
        }

        private OrderWindow ClickPlaceOrder()
        {
            var cartPage = NavigationBar.ClickCartLink();

            return cartPage.PlaceOrder();
        }

        private void ValidatePurchaseAlertMessage(PurchaseAlert purchaseAlert)
        {
            var currentDate = DateTime.Today.AddMonths(-1).ToString("d/M/yyyy", CultureInfo.CreateSpecificCulture("en-US"));

            Assert.That(purchaseAlert.IsPurchaseAlertDisplayed(), Is.True);
            Assert.AreEqual(TestUser.Name, purchaseAlert.GetPurchaseUserName());
            Assert.AreEqual(totalAmount + " USD", purchaseAlert.GetPurchaseTotalAmount());
            Assert.AreEqual(TestUser.CreditCardNumber, purchaseAlert.GetPurchaseCreditCardNumber());
            Assert.AreEqual(currentDate, purchaseAlert.GetPurchaseDate());
        }
    }
}
