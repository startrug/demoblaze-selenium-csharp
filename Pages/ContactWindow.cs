using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }

        public bool IsMessageSentSuccessfully() => IsBrowserAlertShowed(AlertType.MessageSentAlert);

        public override void SetUserEmail(User userData)
        {
            SetText(WindowInputLocator("recipient-email"), userData.Email);
            LoggerHelpers.LogInfoAboutEnteredUserData("contact e-mail", userData.Email);
        }

        public override void SetUserName(User userData)
        {
            SetText(WindowInputLocator("recipient-name"), userData.Name);
            LoggerHelpers.LogInfoAboutEnteredUserData("contact name", userData.Name);
        }

        public override void SetUserMessage(User userData)
        {
            SetText(WindowInputLocator("message-text"), userData.Message);
            LoggerHelpers.LogInfoAboutEnteredUserData("message", userData.Message);
        }

        public override string CurrentWindowId => "#exampleModal";
        public override string WindowSubmitAction => "send()";

        public override string CurrentWindowName => "Contact window";
    }
}