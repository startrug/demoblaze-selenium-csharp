using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class SignUpWindow : BaseWindow
    {
        public SignUpWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => WaitForElementVisibility(CurrentWindowLocator);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override void FillOutForm(UserData contactFormData)
            => base.FillOutForm(contactFormData);

        public override void SetInputValues(UserData contactFormData)
        {
            SetUserName(contactFormData);
            SetUserPassword(contactFormData);
        }

        private void SetUserPassword(UserData userFormData)
            => SetText(SignInPasswordInputLocator, userFormData.Password);

        private void SetUserName(UserData userFormData)
            => SetText(SignInUserNameInputLocator, userFormData.Name);

        public bool IsUserSignedInSuccessfully()
            => Alert.IsBrowserAlertContainsExpectedMessage(SignUpSuccessfullMessage);

        public bool IsUserAlreadyExisting()
            => Alert.IsBrowserAlertContainsExpectedMessage(UserExistsMessage);

        public bool IsUserDidNotEnterRequiredData()
            => Alert.IsBrowserAlertContainsExpectedMessage(MissingSignInDataMessage);

        public override string CurrentWindowId => "[id='signInModal']";
        public override string WindowSubmitAction => "register()";

        public By SignInUserNameInputLocator => By.Id("sign-username");
        public By SignInPasswordInputLocator => By.Id("sign-password");

        public string SignUpSuccessfullMessage => "Sign up successful.";
        public string UserExistsMessage => "This user already exist.";
        public string MissingSignInDataMessage => "Please fill out Username and Password.";
    }
}