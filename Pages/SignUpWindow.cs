using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class SignUpWindow : BaseWindow
    {
        public SignUpWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override void FillOutFormWithBrowserAlert(User customerData)
            => base.FillOutFormWithBrowserAlert(customerData);

        public override void SetInputValues(User customerData)
        {
            SetUserName(customerData);
            SetUserPassword(customerData);
        }

        private void SetUserPassword(User customerData)
            => SetText(WindowInputLocator("sign-password"), customerData.Password);

        private void SetUserName(User customerData)
            => SetText(WindowInputLocator("sign-username"), customerData.Name);

        public bool IsUserSignedInSuccessfullyAlertShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(SignUpSuccessfullMessage);

        public bool IsUserAlreadyExistaAlertShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(UserExistsMessage);

        public bool IsRequestToCompleteFormAlertIsShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(RequestToCompleteFormAlert);

        public override string CurrentWindowId => "#signInModal";
        public override string WindowSubmitAction => "register()";

        public string SignUpSuccessfullMessage => "Sign up successful.";
        public string UserExistsMessage => "This user already exist.";
        public string RequestToCompleteFormAlert => "Please fill out Username and Password.";
    }
}