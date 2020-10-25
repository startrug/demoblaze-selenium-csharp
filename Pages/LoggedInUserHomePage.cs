using demoblaze_selenium_csharp.Models;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LoggedInUserHomePage : HomePage
    {
        public LoggedInUserHomePage(IWebDriver driver, User userData) : base(driver)
        {
            loggedInUserData = userData;
        }

        internal bool IsUserLoggedInSuccessfully()
        {
            IsElementDisplayedAfterWaiting(WelcomeUserLocator);

            return GetTextOfElement(WelcomeUserLocator).Equals(WelcomeUserText);
        }

        public By WelcomeUserLocator => By.Id("nameofuser");

        public string WelcomeUserText => $"Welcome {loggedInUserData.Name}";

        private readonly User loggedInUserData;
    }
}