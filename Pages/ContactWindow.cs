using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened()
        {
            var testStepResult = IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            Reporter.LogTestStep(
                testStepResult,
                "Contact window has been opened successfully",
                "Contact window has not been opened"
                );
            return testStepResult;
        }

        public override bool IsWindowClosed()
        {
            var testStepResult = IsElementDisplayedImmediately(CurrentWindowLocator);
            Reporter.LogTestStep(
                testStepResult,
                "Contact window has been closed successfully",
                "Contact window has not been closed"
                );
            return testStepResult;
        }

        public override void FillOutFormWithBrowserAlert(User userData)
            => base.FillOutFormWithBrowserAlert(userData);

        public override void SetInputValues(User userData)
        {
            SetUserEmail(userData);
            Reporter.LogPassingTestStep($"User email was successfully set to \"{userData.Email}\"");
            SetUserName(userData);
            Reporter.LogPassingTestStep($"User name was successfully set to \"{userData.Name}\"");
            SetUserMessage(userData);
            Reporter.LogPassingTestStep($"User message was successfully set to \"{userData.Message}\"");
        }

        public bool IsMessageSentSuccessfully()
            => Alert.IsBrowserAlertContainsExpectedMessage(MessageSentAlert);

        private void SetUserEmail(User userData) =>
            SetText(WindowInputLocator("recipient-email"), userData.Email);

        private void SetUserName(User userData)
            => SetText(WindowInputLocator("recipient-name"), userData.Name);

        private void SetUserMessage(User userData)
            => SetText(WindowInputLocator("message-text"), userData.Message);

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override string CurrentWindowId => "#exampleModal";
        public override string WindowSubmitAction => "send()";

        private string MessageSentAlert => "Thanks for the message!!";
    }
}