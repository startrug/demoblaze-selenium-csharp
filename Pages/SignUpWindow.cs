using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class SignUpWindow : BaseWindow
    {
        public SignUpWindow(IWebDriver driver) : base(driver) { }        

        public override bool IsWindowOpened() => WaitForElementVisibility(WindowLocator);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowLocator);
            Click(CloseWindowLocator);
        }

        public override By WindowLocator => By.XPath(SignUpWindowXpath + base.WindowXpath);
        public override By CloseWindowLocator => By.XPath(SignUpWindowXpath + base.WindowXpath);
        public string SignUpWindowXpath => "//div[@id='signInModal']";
    }
}