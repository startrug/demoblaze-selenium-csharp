using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class HomepageTests : BaseTest
    {
        [Test, Order(1)]
        public void GivenUrlAddress_WhenUserOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {           
            Assert.That(DemoBlazeHomePage.IsPageOpened(), Is.True);
            Assert.That(DemoBlazeHomePage.IsPageTitleCorrect(), Is.True);
        }

        [Test, Order(2)]
        public void GivenNewContactPage_WhenUserOpensContactPage_ThenPageIsOpened()
        {            
            ContactPage = DemoBlazeHomePage.ClickContactLink();

            Assert.That(ContactPage.IsWindowOpened(), Is.True);
        }

        [Test, Order(3)]
        public void GivenNewContactPage_WhenUserClosesContactPage_ThenPageIsClosed()
        {
            ContactPage = DemoBlazeHomePage.ClickContactLink();
            ContactPage.ClickClose();

            Assert.That(ContactPage.IsWindowClosed(), Is.True);
        }

        [Test, Order(4)]
        public void GivenNewAboutUsPage_WhenUserOpensAboutUsPage_ThenVideoInPageIsAvailable()
        {
            AboutUsPage = DemoBlazeHomePage.ClickAboutUsLink();
            
            Assert.That(AboutUsPage.IsVideoAvailable(), Is.True);
        }

        [Test, Order(4)]
        public void GivenNewCartPage_WhenUserOpensCartPage_ThenPageIsOpened()
        {
            CartPage = DemoBlazeHomePage.ClickCartLink();

            Assert.That(CartPage.IsCartPageOpened(), Is.True);
        }
    }
}
