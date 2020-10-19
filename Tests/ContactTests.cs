using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("ContactTests")]
    public class ContactTests : BaseTest<ContactWindow>
    {
        [Test]
        public void WhenCustomerOpensContactPage_ThenPageIsOpened()
        {
            Assert.That(TestedPageOrWindow.IsWindowOpened(), Is.True);
        }

        [Test]
        public void GivenCustomerContactFormData_WhenCustomerFillOutContactFormAndClickSendMessageButton_ThenMessageIsSent()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(TestedPageOrWindow.IsMessageSentSuccessfully, Is.True);
        }

        [Test]
        public void WhenCustomerClosesContactPage_ThenPageIsClosed()
        {
            TestedPageOrWindow.ClickCloseWindow();

            Assert.That(TestedPageOrWindow.IsWindowClosed(), Is.True);
        }

        protected override ContactWindow SelectTestedAppPage()
            => NavigationBar.ClickContactLink();
    }
}
