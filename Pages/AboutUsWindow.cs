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

        public override string CurrentWindowId => "[id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
        public override string CurrentWindowName => "About us window";
    }
}