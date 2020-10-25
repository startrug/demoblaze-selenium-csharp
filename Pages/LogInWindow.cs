using demoblaze_selenium_csharp.Data;
using demoblaze_selenium_csharp.Models;
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

        public bool IsWrongPasswordAlertShowed() => IsBrowserAlertShowed(AlertMessages.WrongPassword);

        internal bool IsRequestToCompleteFormAlertIsShowed() => IsBrowserAlertShowed(AlertMessages.RequestToCompleteForm);

        public override void SetUserName(User userData) => SetText(WindowInputLocator("loginusername"), userData.Name);

        public override void SetUserPassword(User userData) => SetText(WindowInputLocator("loginpassword"), userData.Password);

        public override string CurrentWindowId => "#logInModal";
        public override string WindowSubmitAction => "logIn()";
        public override string CurrentWindowName => "Log in window";
    }
}