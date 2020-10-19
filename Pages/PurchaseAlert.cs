using System;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class PurchaseAlert : BaseWindow
    {
        private readonly int[] Id = { 0, 4 };
        private readonly int[] TotalAmount = { 1, 8 };
        private readonly int[] CreditCardNumber = { 2, 13 };
        private readonly int[] PurchaseDate = { 4, 6 };
        private readonly int[] UserName = { 3, 6 };

        public PurchaseAlert(IWebDriver driver) : base(driver) { }

        public bool IsPurchaseAlertDisplayed() => IsElementDisplayedAfterWaiting(PurchaseAlertLocator);

        public By PurchaseAlertLocator => By.CssSelector(".sweet-alert");

        public By PurchaseIdLocator => By.CssSelector("p[class^='lead']");

        internal string[] GetPurchaseMessageInLines()
        {
            var purchaseMessage = GetTextOfElement(PurchaseIdLocator);
            string[] sep = new string[] { "\r\n" };

            return purchaseMessage.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        }

        internal string GetPurchaseId() => GetPurchaseData(Id);
        internal string GetPurchaseTotalAmount() => GetPurchaseData(TotalAmount);
        internal string GetPurchaseCreditCardNumber() => GetPurchaseData(CreditCardNumber);
        internal string GetPurchaseDate() => GetPurchaseData(PurchaseDate);
        internal string GetPurchaseUserName() => GetPurchaseData(UserName);

        internal string GetPurchaseData(int[] dataType)
        {
            var idLine = GetPurchaseMessageInLines()[dataType[0]];

            return idLine.Substring(dataType[1]);
        }
    }
}