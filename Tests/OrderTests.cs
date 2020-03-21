using System;
using System.Globalization;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class OrderTests : BaseTest
    {
        [Test, Order(10)]
        public void GivenRequiredCustomerData_WhenCustomerFillsOutOrderForm_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);

            OrderWindow = CartPage.PlaceOrder();
            PurchaseAlert = OrderWindow.FillOutFormAndPurchase(TestUser);

            ValidatePurchaseAlertMessage();
        }

        [Test, Order(11)]
        public void GivenProductAndAllCustomerData_WhenCustomerAddsProductToCartFillsOutOrderFormAndConfirmsIt_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(NewMonitor);

            TotalAmount = ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed, Is.True);
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            OrderWindow = CartPage.PlaceOrder();
            Assert.That(OrderWindow.GetTotalAmountFromOrderWindow() == TotalAmount, Is.True);
            PurchaseAlert = OrderWindow.FillOutFormAndPurchase(TestUser);

            ValidatePurchaseAlertMessage();
        }

        [Test, Order(12)]
        public void WhenCustomerDidNotFillOutRequiredFildsOfOrderFormAndAcceptIt_ThenEnterRequiredDataAlertIsShowed()
        {
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);

            OrderWindow = CartPage.PlaceOrder();
            OrderWindow.FillOutFormWithBrowserAlert(TestUserWithMissingData);

            Assert.That(OrderWindow.IsEnterRequiredDataAlertShowed(), Is.True);
        }

        private void ValidatePurchaseAlertMessage()
        {
            var currentDate = DateTime.Today.AddMonths(-1).ToString("dd/M/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            Assert.That(PurchaseAlert.IsPurchaseAlertDisplayed(), Is.True);
            Assert.That(PurchaseAlert.GetPurchaseUserName() == TestUser.Name, Is.True);
            Assert.That(PurchaseAlert.GetPurchaseTotalAmount() == TotalAmount + " USD", Is.True);
            Assert.That(PurchaseAlert.GetPurchaseCreditCardNumber() == TestUser.CreditCardNumber, Is.True);
            Assert.That(PurchaseAlert.GetPurchaseDate() == currentDate, Is.True);
        }
    }
}
