using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class AboutUsWindow : BaseWindow
    {
        public AboutUsWindow(IWebDriver driver) : base(driver) { }

        internal bool IsVideoAvailable() => IsElementDisplayedAfterWaiting(ExampleVideoLocator);

        public override string CurrentWindowId => "[id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
        public override string CurrentWindowName => "About us window";
    }
}