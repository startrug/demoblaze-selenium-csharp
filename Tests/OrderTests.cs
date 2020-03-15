﻿using System;
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
        public void GivenRequiredUserData_WhenUserFillsOutOrderForm_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);

            OrderWindow = CartPage.PlaceOrder();
            PurchaseAlert = OrderWindow.FillOutFormAndPurchase(TestCustomerData);

            ValidatePurchaseAlertMessage();
        }

        [Test, Order(11)]
        public void GivenProductAndAllCustomerData_WhenCustomerAddsProductToCartFillsOutOrderFormAndConfirmsIt_ThenPurchaseAlertWithInputtedDataIsShowed()
        {
            ProductPage = DemoBlazeHomePage.SelectProductAndOpenProductPage(NewMonitor);

            TotalOrder = ProductPage.AddProductToCart();
            Assert.That(ProductPage.IsProductAddedAlertShowed, Is.True);
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
            OrderWindow = CartPage.PlaceOrder();
            PurchaseAlert = OrderWindow.FillOutFormAndPurchase(TestCustomerData);

            ValidatePurchaseAlertMessage();
        }

        private void ValidatePurchaseAlertMessage()
        {
            var currentDate = DateTime.Today.AddMonths(-1).ToString("dd/M/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            Assert.That(PurchaseAlert.IsPurchaseAlertDisplayed(), Is.True);
            Assert.That(PurchaseAlert.GetPurchaseUserName() == TestCustomerData.Name, Is.True);
            Assert.That(PurchaseAlert.GetPurchaseTotalAmount() == TotalOrder + " USD", Is.True);
            Assert.That(PurchaseAlert.GetPurchaseCreditCardNumber() == TestCustomerData.CreditCardNumber, Is.True);
            Assert.That(PurchaseAlert.GetPurchaseDate() == currentDate, Is.True);
        }
    }
}