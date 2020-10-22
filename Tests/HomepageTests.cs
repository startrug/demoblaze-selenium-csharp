using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("HomepageTests")]
    public class HomepageTests : BaseTest<HomePage>
    {
        [Test]
        public void WhenCustomerOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {
            Assert.IsTrue(TestedPageOrWindow.IsPageOpened());
            Assert.IsTrue(TestedPageOrWindow.IsPageTitleCorrect());
        }

        [Test]
        public void WhenCustomerOpensAboutUsPage_ThenWindowIsOpenedVideoIsAvailable()
        {
            var aboutUsWindow = NavigationBar.ClickAboutLink();

            Assert.IsTrue(aboutUsWindow.IsWindowOpened());
            Assert.IsTrue(aboutUsWindow.IsVideoAvailable());
        }

        [Test]
        public void WhenCustomerClicksNextButtonOnSlider_ThenImageChanges()
        {
            Assert.IsTrue(TestedPageOrWindow.Slider.IsImageChanged());
        }

        protected override HomePage SelectTestedAppPage()
            => NavigationBar.ClickHomeLink();

    }
}
