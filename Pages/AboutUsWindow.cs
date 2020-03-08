using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public class AboutUsWindow : BaseWindow
    {
        public AboutUsWindow(IWebDriver driver) : base(driver) {}

        internal bool IsVideoAvailable() => WaitForElementVisibility(ExampleVideoLocator);

        public override bool IsWindowOpened() => WaitForElementVisibility(CurrentWindowLocator);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public override string CurrentWindowId => "[id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
    }
}