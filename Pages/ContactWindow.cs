using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        public ContactWindow(IWebDriver driver) : base(driver) { }        

        public override bool IsWindowOpened() => WaitForElementVisibility(WindowLocator);

        public override bool IsWindowClosed() => IsElementDisplayed(WindowLocator);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowLocator);
            Click(CloseWindowLocator);
        }

        public override By WindowLocator => By.XPath(ContactWindowXpath + base.WindowXpath);
        public override By CloseWindowLocator => By.XPath(ContactWindowXpath + base.WindowXpath);
        public string ContactWindowXpath => "//div[@id='exampleModal']";
    }    
}