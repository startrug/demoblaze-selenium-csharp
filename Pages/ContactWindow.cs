using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => WaitForElementVisibility(CurrentWindowLocator);

        public override bool IsWindowClosed() => IsElementDisplayed(CurrentWindowLocator);

        public override void FillOutForm(UserData contactFormData)
        {
            WaitForElementVisibility(CurrentWindowLocator);
            SetUserEmail(contactFormData);
            SetUserName(contactFormData);
            SetUserMessage(contactFormData);
            Click(SubmitWindowButtonLocator);
            WaitForBrowserAlert();
        }

        public bool IsMessageSentSuccessfully()
            => Alert.IsBrowserAlertContainsExpectedMessage("Thanks for the message!!");

        private void SetUserEmail(UserData contactFormData) =>
            SetText(EmailInputLocator, contactFormData.Email);

        private void SetUserName(UserData contactFormData)
            => SetText(NameInputLocator, contactFormData.Name);

        private void SetUserMessage(UserData contactFormData)
            => SetText(MessageInputLocator, contactFormData.Message);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public By EmailInputLocator => By.Id("recipient-email");
        public By NameInputLocator => By.Id("recipient-name");
        public By MessageInputLocator => By.Id("message-text");

        public override string CurrentWindowId => "[id='exampleModal']";
        public override string WindowSubmitAction => "send()";
    }
}