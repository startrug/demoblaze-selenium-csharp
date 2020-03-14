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

        internal string GetPurchaseId() => GetPurchaseData(0, 4);
        internal string GetPurchaseTotalAmount() => GetPurchaseData(1, 8);
        internal string GetPurchaseCreditCardNumber() => GetPurchaseData(2, 13);
        internal string GetPurchaseDate() => GetPurchaseData(4, 6);
        internal string GetPurchaseUserName() => GetPurchaseData(3, 6);

        internal string GetPurchaseData(int lineNumber, int startCharNumber)
        {
            var idLine = GetPurchaseMessageInLines()[lineNumber];
            return idLine.Substring(startCharNumber);
        }
    }
}