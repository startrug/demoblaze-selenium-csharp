using System;
using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Tests
{
    public class AboutUsWindow : BaseWindow
    {
        public AboutUsWindow(IWebDriver driver) : base(driver) {}                

        internal bool IsVideoAvailable() => WaitForElementVisibility(ExampleVideoLocator);        

        public override bool IsWindowOpened() => WaitForElementVisibility(WindowLocator);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowLocator);
            Click(CloseWindowLocator);
        }

        public override By WindowLocator => By.XPath(AboutUsWindowXpath + base.WindowXpath);
        public override By CloseWindowLocator => By.XPath(AboutUsWindowXpath + base.CloseWindowXpath);

        public string AboutUsWindowXpath => "//div[@id='videoModal']";
        public By ExampleVideoLocator => By.Id("example-video_html5_api");
    }
}