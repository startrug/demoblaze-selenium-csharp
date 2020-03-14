using demoblaze_selenium_csharp.Enums;
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

        [Test, Order(5)]
        public void WhenUserOpensAboutUsPage_ThenWindowIsOpenedVideoIsAvailable()
        {
            AboutUsWindow = DemoBlazeHomePage.ClickLink<AboutUsWindow>(LinkText.AboutUs);

            Assert.That(AboutUsWindow.IsWindowOpened(), Is.True);
            Assert.That(AboutUsWindow.IsVideoAvailable(), Is.True);
        }
    }
}
