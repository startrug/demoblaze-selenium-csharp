using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LoggedInUserHomePage : HomePage
    {
        private readonly CustomerData loggedInUserData;

        public LoggedInUserHomePage(IWebDriver driver, CustomerData userData) : base(driver)
        {
            loggedInUserData = userData;
        }

        internal bool IsUserLoggedInSuccessfully()
        {
            IsElementDisplayedAfterWaiting(WelcomeUserLocator);
            return GetTextOfElement(WelcomeUserLocator) == WelcomeUserText;
        }

        public By WelcomeUserLocator => By.Id("nameofuser");

        public string WelcomeUserText => $"Welcome {loggedInUserData.Name}";
    }
}