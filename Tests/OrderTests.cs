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

            PurchaseAlert = OrderWindow.FillOutFormAndPurchase(TestUserData);
            ValidatePurchaseAlertMessage();
        }

        private void ValidatePurchaseAlertMessage()
        {
            Assert.That(PurchaseAlert.IsPurchaseAlertDisplayed(), Is.True);
            Assert.That(PurchaseAlert.GetPurchaseUserName() == TestUserData.Name, Is.True);
            Assert.That(PurchaseAlert.GetPurchaseTotal() == TotalOrder + " USD", Is.True);
        }
    }
}
