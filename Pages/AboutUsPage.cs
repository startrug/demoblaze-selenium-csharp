using System;
using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public class AboutUsPage : BasePage
    {
        public AboutUsPage(IWebDriver driver) : base(driver) {}

        public By ExampleVideoLocator => By.Id("example-video_html5_api");        

        internal bool IsVideoAvailable() => WaitForElement(ExampleVideoLocator).Displayed;                
    }
}