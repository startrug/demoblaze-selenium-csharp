using System;
using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public class AboutUsWindow : BasePage
    {
        public AboutUsWindow(IWebDriver driver) : base(driver) {}

        public By ExampleVideoLocator => By.Id("example-video_html5_api");

        public By AboutUsWindowLocator => By.XPath($"//div[@id='videoModal']" +
            $"{WindowContentLocator}");

        internal bool IsVideoAvailable() => WaitForElementVisibility(ExampleVideoLocator);                
    }
}