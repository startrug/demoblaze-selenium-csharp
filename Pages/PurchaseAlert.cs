using System;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class PurchaseAlert : BaseWindow
    {
        public PurchaseAlert(IWebDriver driver) : base(driver) { }

        public bool IsPurchaseAlertDisplayed()
            => IsElementDisplayedAfterWaiting(PurchaseAlertLocator);

        public By PurchaseAlertLocator => By.CssSelector(".sweet-alert");

        public By PurchaseIdLocator => By.CssSelector("p[class^='lead']");

        internal string[] GetPurchaseMessageInLines()
        {
            var purchaseMessage = GetTextOfElement(PurchaseIdLocator);
            string[] sep = new string[] { "\r\n" };
            return purchaseMessage.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        }

        internal string GetPurchaseId()
        {
            var idLine = GetPurchaseMessageInLines()[0];
            return idLine.Substring(4);
        }

        internal string GetPurchaseTotal()
        {
            var idLine = GetPurchaseMessageInLines()[1];
            return idLine.Substring(8);
        }

        internal string GetPurchaseUserName()
        {
            var idLine = GetPurchaseMessageInLines()[3];
            return idLine.Substring(6);
        }
    }
}