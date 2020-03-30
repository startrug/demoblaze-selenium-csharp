using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("ContactTests")]
    public class ContactTests : ContactBaseTest
    {
        public override void SetupBeforeEveryContactTest() => base.SetupBeforeEveryContactTest();

        [Test, Order(2)]
        public void WhenCustomerOpensContactPage_ThenPageIsOpened()
        {
            Assert.That(ContactWindow.IsWindowOpened(), Is.True);
        }

        [Test, Order(3)]
        public void GivenCustomerContactFormData_WhenCustomerFillOutContactFormAndClickSendMessageButton_ThenMessageIsSent()
        {
            ContactWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(ContactWindow.IsMessageSentSuccessfully, Is.True);
        }

        [Test, Order(4)]
        public void WhenCustomerClosesContactPage_ThenPageIsClosed()
        {
            ContactWindow.ClickCloseWindow();

            Assert.That(ContactWindow.IsWindowClosed(), Is.True);
        }
    }
}
