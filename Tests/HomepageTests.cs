using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("HomepageTests")]
    public class HomepageTests : BaseTest<HomePage>
    {
        [Test, Order(1)]
        public void WhenCustomerOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {
            Assert.That(TestedPageOrWindow.IsPageOpened(), Is.True);
            Assert.That(TestedPageOrWindow.IsPageTitleCorrect(), Is.True);
        }

        [Test, Order(2)]
        public void WhenCustomerOpensAboutUsPage_ThenWindowIsOpenedVideoIsAvailable()
        {
            var aboutUsWindow = NavigationBar.ClickAboutLink();

            Assert.That(aboutUsWindow.IsWindowOpened(), Is.True);
            Assert.That(aboutUsWindow.IsVideoAvailable(), Is.True);
        }

        protected override HomePage SelectTestedAppPage()
            => NavigationBar.ClickHomeLink();

    }
}
