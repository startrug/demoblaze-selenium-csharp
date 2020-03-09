using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LoggedInUserHomePage : HomePage
    {
        private readonly UserData loggedInUserData;

        public LoggedInUserHomePage(IWebDriver driver, UserData userData) : base(driver)
        {
            loggedInUserData = userData;
        }

        internal bool IsUserLoggedInSuccessfully()
        {
            WaitForElementVisibility(WelcomeUserLocator);
            return GetTextOfElement(WelcomeUserLocator) == WelcomeUserText;
        }

        public By WelcomeUserLocator => By.Id("nameofuser");

        public string WelcomeUserText => $"Welcome {loggedInUserData.Name}";
    }
}