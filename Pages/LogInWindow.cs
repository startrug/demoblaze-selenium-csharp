using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LogInWindow : BaseWindow
    {
        public LogInWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => WaitForElementVisibility(CurrentWindowLocator);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override void FillOutForm(UserData userData) => base.FillOutForm(userData);

        public override void SetInputValues(UserData userData)
        {
            SetUserName(userData);
            SetUserPassword(userData);
        }

        public LoggedInUserHomePage FillOutFormAndLogIn(UserData userData)
        {
            WaitForElementVisibility(CurrentWindowLocator);
            SetInputValues(userData);
            Click(SubmitWindowButtonLocator);
            return new LoggedInUserHomePage(_driver, userData);
        }

        private void SetUserName(UserData userData)
            => SetText(LogInUserNameInputLocator, userData.Name);

        private void SetUserPassword(UserData userData)
            => SetText(LogInPasswordInputLocator, userData.Password);

        public override string CurrentWindowId => "[id='logInModal']";

        private By LogInPasswordInputLocator => By.Id("loginpassword");
        private By LogInUserNameInputLocator => By.Id("loginusername");

        public override string WindowSubmitAction => "logIn()";
    }
}