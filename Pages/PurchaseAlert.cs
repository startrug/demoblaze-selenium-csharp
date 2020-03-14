using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class PurchaseAlert : BaseWindow
    {
        public PurchaseAlert(IWebDriver driver) : base(driver) { }

        public bool IsPurchaseAlertDisplayed()
            => IsElementDisplayedAfterWaiting(PurchaseAlertLocator);

        public By PurchaseAlertLocator => By.CssSelector(".sweet-alert");
    }
}