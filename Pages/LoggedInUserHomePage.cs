using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

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
            Reporter.LogTestStep(
                testStepResult,
                $"The user {loggedInUserData.Name} has been logged in successfully",
                $"The user {loggedInUserData.Name} has not been logged in"
                );
            return testStepResult;
        }

        public By WelcomeUserLocator => By.Id("nameofuser");

        public string WelcomeUserText => $"Welcome {loggedInUserData.Name}";
    }
}