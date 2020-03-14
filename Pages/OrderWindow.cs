using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class OrderWindow : BaseWindow
    {
        public OrderWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => WaitForElementVisibility(CurrentWindowLocator);

        public override string CurrentWindowId => "#orderModal";
    }
}