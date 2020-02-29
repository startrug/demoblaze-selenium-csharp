using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class HomepageTests
    {
        public IWebDriver Driver { get; private set; }
        public DemoBlazeHomePage DemoBlazeHomePage { get; private set; }
        public ContactPage ContactPage { get; private set; }

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            DemoBlazeHomePage = new DemoBlazeHomePage(Driver);
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Test]
        public void GivenUrlAddress_WhenUserOpenHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {            
            DemoBlazeHomePage.GoTo();

            Assert.That(DemoBlazeHomePage.PageIsOpened(), Is.True);
            Assert.That(DemoBlazeHomePage.PageTitleIsCorrect(), Is.True);
        }

        [Test]
        public void GivenNewContactPage_WhenUserOpenContactPage_ThenContactPageIsOpened()
        {
            DemoBlazeHomePage.GoTo();
            ContactPage = DemoBlazeHomePage.ClickContactLink();

            Assert.That(ContactPage.ContactPageIsOpened(), Is.True);
        }
    }
}
