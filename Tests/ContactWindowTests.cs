using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class ContactWindowTests : BaseTest
    {
        [Test, Order(1)]
        public void GivenUserContactFormData_WhenUserFillOutContactFormAndClickSendMessageButton_ThenMessageIsSent()
        {           
            ContactWindow = DemoBlazeHomePage.ClickContactLink();
            ContactWindow.FillOutForm(TestUserData);

            Assert.That(ContactWindow.IsMessageSentSuccessfully, Is.True);
        }

        [Test, Order(2)]
        public void WhenUserClosesContactPage_ThenPageIsClosed()
        {
            ContactWindow = DemoBlazeHomePage.ClickContactLink();
            ContactWindow.ClickCloseWindow();

            Assert.That(ContactWindow.IsWindowClosed(), Is.True);
        }
    }
}
