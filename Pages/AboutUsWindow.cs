using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public class AboutUsWindow : BaseWindow
    {
        public AboutUsWindow(IWebDriver driver) : base(driver) {}

        internal bool IsVideoAvailable()
        {
            var testStepResult = IsElementDisplayedAfterWaiting(ExampleVideoLocator);
            LoggerHelpers.LogInfoAboutWebElementDisplayed(testStepResult, "Sample video");

            return testStepResult;
        }

        public override string CurrentWindowId => "[id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
        public override string CurrentWindowName => "About us window";
    }
}