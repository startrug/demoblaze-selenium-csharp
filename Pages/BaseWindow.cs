using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class BaseWindow : BasePage
    {
        public BaseWindow(IWebDriver driver) : base(driver) { }        

        public virtual void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowLocator);
            Click(CloseWindowLocator);
        }

        public virtual bool IsWindowOpened() => IsElementDisplayed(WindowLocator);
        public virtual bool IsWindowClosed() => IsElementDisplayed(WindowLocator);

        public virtual string WindowXpath => "//div[@class='modal-content']";
        public virtual string CloseWindowXpath => "//*[@aria-label='Close']";
        public virtual By CloseWindowLocator { get; set; }
        public virtual By WindowLocator { get; set; }
    }
}