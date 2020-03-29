using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LoggedInUserHomePage : HomePage
    {
        private readonly User loggedInUserData;

        public LoggedInUserHomePage(IWebDriver driver, User userData) : base(driver)
        {
            loggedInUserData = userData;
        }

        internal bool IsUserLoggedInSuccessfully()
        {
            IsElementDisplayedAfterWaiting(WelcomeUserLocator);
            var testStepResult = GetTextOfElement(WelcomeUserLocator) == WelcomeUserText;
            LoggerHelpers.LogInfoAboutLoggedInUser(testStepResult, loggedInUserData.Name);

            return testStepResult;
        }

        public By WelcomeUserLocator => By.Id("nameofuser");

        public string WelcomeUserText => $"Welcome {loggedInUserData.Name}";
    }
}