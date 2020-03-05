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
            ContactFormData = new ContactFormData("anowak@poczta.pl", "Anna Nowak", "Sample message");
            
            ContactWindow = DemoBlazeHomePage.ClickContactLink();
            ContactWindow.FillOutContactForm(ContactFormData);

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
