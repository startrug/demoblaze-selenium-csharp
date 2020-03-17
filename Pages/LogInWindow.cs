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

        public override void SetInputValues(CustomerData customerData)
        {
            SetUserName(customerData);
            SetUserPassword(customerData);
        }

        public LoggedInUserHomePage FillOutFormAndLogIn(CustomerData customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);
            return new LoggedInUserHomePage(Driver, customerData);
        }

        public bool IsWrongPasswordAlertShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(WrongPasswordAlert);

        internal bool IsRequestToCompleteFormAlertIsShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(RequestToCompleteFormAlert);

        private void SetUserName(CustomerData userData)
            => SetText(WindowInputLocator("loginusername"), userData.Name);

        private void SetUserPassword(CustomerData userData)
            => SetText(WindowInputLocator("loginpassword"), userData.Password);

        public override string CurrentWindowId => "#logInModal";

        public override string WindowSubmitAction => "logIn()";

        public string WrongPasswordAlert => "Wrong password.";

        public string RequestToCompleteFormAlert => "Please fill out Username and Password.";
    }
}