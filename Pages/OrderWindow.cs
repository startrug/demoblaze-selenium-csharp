using demoblaze_selenium_csharp.Data;
using demoblaze_selenium_csharp.Models;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class OrderWindow : BaseWindow
    {
        public OrderWindow(IWebDriver driver) : base(driver) { }

        public PurchaseAlert FillOutFormAndPurchase(User customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);

            return new PurchaseAlert(Driver);
        }

        internal int GetTotalAmountFromOrderWindow()
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);

            return int.Parse(GetTextOfElement(TotalAmountLocator).Substring(7));
        }

        internal bool IsEnterRequiredDataAlertShowed() => IsBrowserAlertShowed(AlertMessages.RequestToEnterRequiredData);

        public override void SetUserName(User userData)
            => SetText(WindowInputLocator("name"), userData.Name);
        public override void SetUserCity(User userData)
            => SetText(WindowInputLocator("city"), userData.City);
        public override void SetUserCountry(User userData)
            => SetText(WindowInputLocator("country"), userData.Country);
        public override void SetUserCreditCard(User userData)
            => SetText(WindowInputLocator("card"), userData.CreditCardNumber);
        public override void SetUserCreditCardExpirationYear(User userData)
            => SetText(WindowInputLocator("year"), userData.ExpirationYear);
        public override void SetUserCreditCardExpirationMonth(User userData)
            => SetText(WindowInputLocator("month"), userData.ExpirationMonth);

        public override string CurrentWindowId => "#orderModal";
        public override string WindowSubmitAction => "purchaseOrder()";

        public By TotalAmountLocator => By.Id("totalm");
        public override string CurrentWindowName => "Order window";
    }
}