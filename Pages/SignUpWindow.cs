using demoblaze_selenium_csharp.Models;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class SignUpWindow : BaseWindow
    {
        public SignUpWindow(IWebDriver driver) : base(driver) { }

        public override void SetUserPassword(User userData) => SetText(WindowInputLocator("sign-password"), userData.Password);

        public override void SetUserName(User userData) => SetText(WindowInputLocator("sign-username"), userData.Name);

        public bool IsUserSignedInSuccessfullyAlertShowed() => IsBrowserAlertShowed(AlertType.SignUpSuccessfullAlert);

        public bool IsUserAlreadyExistaAlertShowed() => IsBrowserAlertShowed(AlertType.UserAlreadyExistsAlert);

        public bool IsRequestToCompleteFormAlertIsShowed() => IsBrowserAlertShowed(AlertType.RequestToCompleteFormAlert);

        public override string CurrentWindowId => "#signInModal";
        public override string WindowSubmitAction => "register()";

        public override string CurrentWindowName => "Sign up window";
    }
}