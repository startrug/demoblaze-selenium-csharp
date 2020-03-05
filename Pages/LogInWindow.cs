using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LogInWindow : BaseWindow
    {
        public LogInWindow(IWebDriver driver) : base(driver) { }        

        public override bool IsWindowOpened() => WaitForElementVisibility(WindowLocator);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowLocator);
            Click(CloseWindowLocator);
        }

        public override By WindowLocator => By.XPath(LogInWindowXpath + base.WindowXpath);
        public override By CloseWindowLocator => By.XPath(LogInWindowXpath + base.WindowXpath);
        public string LogInWindowXpath => "//div[@id='logInModal']";
    }
}