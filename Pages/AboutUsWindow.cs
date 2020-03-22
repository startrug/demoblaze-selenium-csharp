using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Tests
{
    public class AboutUsWindow : BaseWindow
    {
        public AboutUsWindow(IWebDriver driver) : base(driver) {}

        internal bool IsVideoAvailable()
        {
            var testStepResult = IsElementDisplayedAfterWaiting(ExampleVideoLocator);
            Reporter.LogTestStep(
                testStepResult,
                "Sample video has been displayed",
                "Sample video has not been displayed"
                );
            return testStepResult;
        }

        public override bool IsWindowOpened()
        {
            var testStepResult = IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            Reporter.LogTestStep(
                testStepResult,
                "About us window has been opened successfully",
                "About us window has not been opened"
                );
            return testStepResult;
        }

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override string CurrentWindowId => "[id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
    }
}