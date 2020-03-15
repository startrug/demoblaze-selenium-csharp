using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public override bool IsWindowClosed() => IsElementDisplayedImmediately(CurrentWindowLocator);

        public override void FillOutFormWithBrowserAlert(CustomerData contactFormData)
            => base.FillOutFormWithBrowserAlert(contactFormData);

        public override void SetInputValues(CustomerData contactFormData)
        {
            SetUserEmail(contactFormData);
            SetUserName(contactFormData);
            SetUserMessage(contactFormData);
        }

        public bool IsMessageSentSuccessfully()
            => Alert.IsBrowserAlertContainsExpectedMessage(MessageSentAlert);

        private void SetUserEmail(CustomerData contactFormData) =>
            SetText(EmailInputLocator, contactFormData.Email);

        private void SetUserName(CustomerData contactFormData)
            => SetText(NameInputLocator, contactFormData.Name);

        private void SetUserMessage(CustomerData contactFormData)
            => SetText(MessageInputLocator, contactFormData.Message);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public By EmailInputLocator => By.Id("recipient-email");
        public By NameInputLocator => By.Id("recipient-name");
        public By MessageInputLocator => By.Id("message-text");

        public override string CurrentWindowId => "#exampleModal";
        public override string WindowSubmitAction => "send()";

        private string MessageSentAlert => "Thanks for the message!!";
    }
}