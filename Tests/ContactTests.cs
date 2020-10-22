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
            Assert.IsTrue(TestedPageOrWindow.IsWindowOpened());
        }

        [Test]
        public void GivenCustomerContactFormData_WhenCustomerFillOutContactFormAndClickSendMessageButton_ThenMessageIsSent()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(User);

            Assert.IsTrue(TestedPageOrWindow.IsMessageSentSuccessfully());
        }

        [Test]
        public void WhenCustomerClosesContactPage_ThenPageIsClosed()
        {
            TestedPageOrWindow.ClickCloseWindow();

            Assert.IsTrue(TestedPageOrWindow.IsWindowClosed());
        }

        protected override ContactWindow SelectTestedAppPage()
            => NavigationBar.ClickContactLink();
    }
}
