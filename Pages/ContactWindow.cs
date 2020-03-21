using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public override bool IsWindowClosed() => IsElementDisplayedImmediately(CurrentWindowLocator);

        public override void FillOutFormWithBrowserAlert(User customerData)
            => base.FillOutFormWithBrowserAlert(customerData);

        public override void SetInputValues(User customerData)
        {
            SetUserEmail(customerData);
            SetUserName(customerData);
            SetUserMessage(customerData);
        }

        public bool IsMessageSentSuccessfully()
            => Alert.IsBrowserAlertContainsExpectedMessage(MessageSentAlert);

        private void SetUserEmail(User customerData) =>
            SetText(WindowInputLocator("recipient-email"), customerData.Email);

        private void SetUserName(User customerData)
            => SetText(WindowInputLocator("recipient-name"), customerData.Name);

        private void SetUserMessage(User customerData)
            => SetText(WindowInputLocator("message-text"), customerData.Message);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override string CurrentWindowId => "#exampleModal";
        public override string WindowSubmitAction => "send()";

        private string MessageSentAlert => "Thanks for the message!!";
    }
}