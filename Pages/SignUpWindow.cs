using demoblaze_selenium_csharp.Data;
using demoblaze_selenium_csharp.Models;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class SignUpWindow : BaseWindow
    {
        public SignUpWindow(IWebDriver driver) : base(driver) { }

        public override void SetUserPassword(User userData) => SetText(WindowInputLocator("sign-password"), userData.Password);

        public override void SetUserName(User userData) => SetText(WindowInputLocator("sign-username"), userData.Name);

        public bool IsUserSignedInSuccessfullyAlertShowed() => IsBrowserAlertShowed(AlertMessages.SignUpSuccessfull);

        public bool IsUserAlreadyExistaAlertShowed() => IsBrowserAlertShowed(AlertMessages.UserAlreadyExists);

        public bool IsRequestToCompleteFormAlertIsShowed() => IsBrowserAlertShowed(AlertMessages.RequestToCompleteForm);

        public override string CurrentWindowId => "#signInModal";
        public override string WindowSubmitAction => "register()";

        public override string CurrentWindowName => "Sign up window";
    }
}