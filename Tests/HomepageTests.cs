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
            ContactWindow = DemoBlazeHomePage.ClickContactLink();

            Assert.That(ContactWindow.IsWindowOpened(WindowType.Contact), Is.True);
        }

        [Test, Order(3)]
        public void GivenNewContactPage_WhenUserClosesContactPage_ThenPageIsClosed()
        {
            ContactWindow = DemoBlazeHomePage.ClickContactLink();
            ContactWindow.ClickClose();

            Assert.That(ContactWindow.IsWindowClosed(), Is.True);
        }

        [Test, Order(4)]
        public void GivenNewAboutUsPage_WhenUserOpensAboutUsPage_ThenWindowIsOpenedVideoIsAvailable()
        {
            AboutUsWindow = DemoBlazeHomePage.ClickAboutUsLink();

            Assert.That(AboutUsWindow.IsWindowOpened(WindowType.AboutUs), Is.True);
            Assert.That(AboutUsWindow.IsVideoAvailable(), Is.True);
        }

        [Test, Order(5)]
        public void GivenNewCartPage_WhenUserOpensCartPage_ThenPageIsOpened()
        {
            CartPage = DemoBlazeHomePage.ClickCartLink();

            Assert.That(CartPage.IsCartPageOpened(), Is.True);
        }

        [Test, Order(6)]
        public void GivenNewLogInWindow_WhenUserOpensLogInWindow_ThenWindowIsOpened()
        {
            LogInWindow = DemoBlazeHomePage.ClickLogInLink();

            Assert.That(LogInWindow.IsWindowOpened(WindowType.LogIn), Is.True);
        }

        [Test, Order(7)]
        public void GivenNewSignUpWindow_WhenUserOpensSignUpWindow_ThenWindowIsOpened()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            Assert.That(SignUpWindow.IsWindowOpened(WindowType.SignUp), Is.True);
        }
    }
}
