using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LogInWindow : BaseWindow
    {
        public LogInWindow(IWebDriver driver) : base(driver) { }

        public LoggedInUserHomePage FillOutFormAndLogIn(User customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);
            return new LoggedInUserHomePage(Driver, customerData);
        }

        public bool IsWrongPasswordAlertShowed() => IsBrowserAlertShowed(AlertType.WrongPasswordAlert);

        internal bool IsRequestToCompleteFormAlertIsShowed() => IsBrowserAlertShowed(AlertType.RequestToCompleteFormAlert);

        public override void SetUserName(User userData)
        {
            SetText(WindowInputLocator("loginusername"), userData.Name);
            LoggerHelpers.LogInfoAboutEnteredUserData("log in name", userData.Name);
        }

        public override void SetUserPassword(User userData)
        {
            SetText(WindowInputLocator("loginpassword"), userData.Password);
            LoggerHelpers.LogInfoAboutEnteredUserData("log in password", userData.Password);
        }

        public override string CurrentWindowId => "#logInModal";
        public override string WindowSubmitAction => "logIn()";
        public override string CurrentWindowName => "Log in window";
    }
}