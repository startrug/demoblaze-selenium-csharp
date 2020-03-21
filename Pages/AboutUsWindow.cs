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
            Reporter.LogPassingTestStep("Sample video was displayed");
            return IsElementDisplayedAfterWaiting(ExampleVideoLocator);
        }

        public override bool IsWindowOpened()
        {
            Reporter.LogPassingTestStep("About us window was opened successfully");
            return IsElementDisplayedAfterWaiting(CurrentWindowLocator);
        }

        public override void ClickCloseWindow() => base.ClickCloseWindow();

        public override string CurrentWindowId => "[id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
    }
}