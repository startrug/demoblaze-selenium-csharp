using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class HomepageTests : BaseTest
    {
        public AboutUsPage AboutUsPage { get; private set; }

        [Test, Order(1)]
        public void GivenUrlAddress_WhenUserOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {           
            Assert.That(DemoBlazeHomePage.PageIsOpened(), Is.True);
            Assert.That(DemoBlazeHomePage.PageTitleIsCorrect(), Is.True);
        }

        [Test, Order(2)]
        public void GivenNewContactPage_WhenUserOpensContactPage_ThenPageIsOpened()
        {            
            ContactPage = DemoBlazeHomePage.ClickContactLink();

            Assert.That(ContactPage.ContactPageIsOpened(), Is.True);
        }

        [Test, Order(3)]
        public void GivenNewAboutUsPage_WhenUserOpensAboutUsPage_ThenPageIsOpenedAndVideoIsAvailable()
        {
            AboutUsPage = DemoBlazeHomePage.ClickAboutUsLink();

            Assert.That(AboutUsPage.AboutUsPageIsOpened(), Is.True);
        }
    }
}
