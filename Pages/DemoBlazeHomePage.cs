using demoblaze_selenium_csharp.Tests;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class DemoBlazeHomePage : BasePage
    {
        public DemoBlazeHomePage(IWebDriver driver) : base(driver) { }

        public string HomePageUrl => "https://www.demoblaze.com/index.html";

        public By NavbarLocator => By.Id("navbarExample");

        public By ContactLocator => By.LinkText("Contact");

        public By AboutUsLocator => By.LinkText("About us");

        public By CartLocator => By.Id("cartur");

        public By LogInLinkLocator => By.Id("login2");

        public By SignUpLinkLocator => By.Id("signin2");

        public const string HomePageTitle = "STORE";

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
        }

        internal bool IsPageOpened() => _driver.FindElement(NavbarLocator).Displayed;

        internal bool IsPageTitleCorrect() => _driver.Title == HomePageTitle;

        internal ContactWindow ClickContactLink()
        {

            Click(ContactLocator);
            return new ContactWindow(_driver);
        }

        internal AboutUsWindow ClickAboutUsLink()
        {
            Click(AboutUsLocator);
            return new AboutUsWindow(_driver);
        }

        internal CartPage ClickCartLink()
        {
            Click(CartLocator);
            return new CartPage(_driver);
        }

        internal LogInWindow ClickLogInLink()
        {
            Click(LogInLinkLocator);
            return new LogInWindow(_driver);
        }

        internal SignUpWindow ClickSignUpLink()
        {
            Click(SignUpLinkLocator);
            return new SignUpWindow(_driver);
        }
    }
}