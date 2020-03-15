using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LogInWindow : BaseWindow
    {
        public LogInWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override void FillOutFormWithBrowserAlert(CustomerData userData) => base.FillOutFormWithBrowserAlert(userData);

        public override void SetInputValues(CustomerData userData)
        {
            SetUserName(userData);
            SetUserPassword(userData);
        }

        public LoggedInUserHomePage FillOutFormAndLogIn(CustomerData userData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(userData);
            Click(SubmitWindowButtonLocator);
            return new LoggedInUserHomePage(Driver, userData);
        }

        public bool IsWrongPasswordAlertShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(WrongPasswordAlert);

        internal bool IsRequestToCompleteFormAlertIsShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(RequestToCompleteFormAlert);

        private void SetUserName(CustomerData userData)
            => SetText(LogInUserNameInputLocator, userData.Name);

        private void SetUserPassword(CustomerData userData)
            => SetText(LogInPasswordInputLocator, userData.Password);

        public override string CurrentWindowId => "#logInModal";

        private By LogInPasswordInputLocator => By.Id("loginpassword");
        private By LogInUserNameInputLocator => By.Id("loginusername");

        public override string WindowSubmitAction => "logIn()";

        public string WrongPasswordAlert => "Wrong password.";

        public string RequestToCompleteFormAlert => "Please fill out Username and Password.";
    }
}