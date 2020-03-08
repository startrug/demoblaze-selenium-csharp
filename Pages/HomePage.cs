using demoblaze_selenium_csharp.Tests;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class HomePage : BasePage
    {
        public const string HomePageTitle = "STORE";

        public HomePage(IWebDriver driver) : base(driver) { }

        internal void GoTo() => _driver.Navigate().GoToUrl(HomePageUrl);

        internal bool IsPageOpened() => _driver.FindElement(HomeLinkLocator).Displayed;

        internal bool IsPageTitleCorrect() => _driver.Title == HomePageTitle;

        internal ContactWindow ClickContactLink()
        {
            Click(ContactLinkLocator);
            return new ContactWindow(_driver);
        }

        internal AboutUsWindow ClickAboutUsLink()
        {
            Click(AboutUsLinkLocator);
            return new AboutUsWindow(_driver);
        }

        internal CartPage ClickCartLink()
        {
            Click(CartLinkLocator);
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

        public string HomePageUrl => "https://www.demoblaze.com/index.html";

        public By HomeLinkLocator => By.PartialLinkText("Home");
        public By ContactLinkLocator => By.LinkText("Contact");
        public By AboutUsLinkLocator => By.LinkText("About us");
        public By CartLinkLocator => By.Id("cartur");
        public By LogInLinkLocator => By.Id("login2");
        public By SignUpLinkLocator => By.Id("signin2");
    }
}