using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class LogInWindow : BaseWindow
    {
        public LogInWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override void FillOutFormWithBrowserAlert(User userData) => base.FillOutFormWithBrowserAlert(userData);

        public override void SetInputValues(User userData)
        {
            SetUserName(userData);
            Reporter.LogPassingTestStep($"User name has been successfully set to \"{userData.Name}\"");
            SetUserPassword(userData);
            Reporter.LogPassingTestStep($"User password has been successfully set to \"{userData.Password}\"");
        }

        public LoggedInUserHomePage FillOutFormAndLogIn(User customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);
            return new LoggedInUserHomePage(Driver, customerData);
        }

        public bool IsWrongPasswordAlertShowed() => IsAlertShowed(AlertType.WrongPasswordAlert);

        internal bool IsRequestToCompleteFormAlertIsShowed() => IsAlertShowed(AlertType.RequestToCompleteFormAlert);

        public override string CurrentWindowId => "#logInModal";

        public override string WindowSubmitAction => "logIn()";

        private void SetUserName(User userData)
            => SetText(WindowInputLocator("loginusername"), userData.Name);

        private void SetUserPassword(User userData)
            => SetText(WindowInputLocator("loginpassword"), userData.Password);
    }
}