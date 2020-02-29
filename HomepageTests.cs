using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demoblaze_selenium_csharp
{
    [TestFixture]
    public class HomepageTests
    {
        public IWebDriver Driver { get; private set; }

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Test]
        public void GivenUrlAddress_WhenUserOpenHomepage_ThenHomePageIsOpenedAndPageTitleIsCorrect()
        {
            DemoBlazeHomePage demoBlazeHomePage = new DemoBlazeHomePage(Driver);            
            demoBlazeHomePage.GoTo();

            Assert.That(demoBlazeHomePage.PageIsOpened(), Is.True);
            Assert.That(demoBlazeHomePage.PageTitleIsCorrect(), Is.True);
        }
    }
}
