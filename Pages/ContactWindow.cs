using demoblaze_selenium_csharp.Data;
using demoblaze_selenium_csharp.Models;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }

        public bool IsMessageSentSuccessfully() => IsBrowserAlertShowed(AlertMessages.MessageSent);

        public override void SetUserEmail(User userData) => SetText(WindowInputLocator("recipient-email"), userData.Email);

        public override void SetUserName(User userData) => SetText(WindowInputLocator("recipient-name"), userData.Name);

        public override void SetUserMessage(User userData) => SetText(WindowInputLocator("message-text"), userData.Message);

        public override string CurrentWindowId => "#exampleModal";
        public override string WindowSubmitAction => "send()";

        public override string CurrentWindowName => "Contact window";
    }
}