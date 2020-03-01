using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactPage : BasePage
    {
        public ContactPage(IWebDriver driver) : base(driver) { }

        public By NewWindowLocator => By.ClassName("modal-content");

        internal bool ContactPageIsOpened() => WaitForElement(NewWindowLocator).Displayed;        
    }
}