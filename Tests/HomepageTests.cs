using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class HomepageTests : BaseTest
    {
        [Test, Order(1)]
        public void GivenUrlAddress_WhenUserOpenHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {           
            Assert.That(DemoBlazeHomePage.PageIsOpened(), Is.True);
            Assert.That(DemoBlazeHomePage.PageTitleIsCorrect(), Is.True);
        }

        [Test, Order(2)]
        public void GivenNewContactPage_WhenUserOpenContactPage_ThenContactPageIsOpened()
        {            
            ContactPage = DemoBlazeHomePage.ClickContactLink();

            Assert.That(ContactPage.ContactPageIsOpened(), Is.True);
        }
    }
}
