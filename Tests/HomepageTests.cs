using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class HomepageTests : BaseTest
    {
        [Test, Order(1)]
        public void WhenUserOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {           
            Assert.That(DemoBlazeHomePage.IsPageOpened(), Is.True);
            Assert.That(DemoBlazeHomePage.IsPageTitleCorrect(), Is.True);
        }

        [Test, Order(2)]
        public void WhenUserOpensContactPage_ThenPageIsOpened()
        {            
            ContactWindow = DemoBlazeHomePage.ClickContactLink();

            Assert.That(ContactWindow.IsWindowOpened(), Is.True);
        }
        
        [Test, Order(4)]
        public void WhenUserOpensAboutUsPage_ThenWindowIsOpenedVideoIsAvailable()
        {
            AboutUsWindow = DemoBlazeHomePage.ClickAboutUsLink();

            Assert.That(AboutUsWindow.IsWindowOpened(), Is.True);
            Assert.That(AboutUsWindow.IsVideoAvailable(), Is.True);
        }

        [Test, Order(5)]
        public void WhenUserOpensCartPage_ThenPageIsOpened()
        {
            CartPage = DemoBlazeHomePage.ClickCartLink();

            Assert.That(CartPage.IsCartPageOpened(), Is.True);
        }

        [Test, Order(6)]
        public void WhenUserOpensLogInWindow_ThenWindowIsOpened()
        {
            LogInWindow = DemoBlazeHomePage.ClickLogInLink();

            Assert.That(LogInWindow.IsWindowOpened(), Is.True);
        }

        [Test, Order(7)]
        public void WhenUserOpensSignUpWindow_ThenWindowIsOpened()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            Assert.That(SignUpWindow.IsWindowOpened(), Is.True);
        }        
    }
}
