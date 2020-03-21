using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class OrderWindow : BaseWindow
    {
        public OrderWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public PurchaseAlert FillOutFormAndPurchase(User customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);
            return new PurchaseAlert(Driver);
        }

        public override void SetInputValues(User customerData)
        {
            SetCustomerName(customerData);
            SetCustomerCountry(customerData);
            SetCustomerCity(customerData);
            SetCustomerCreditCard(customerData);
            SetCustomerCreditCardExpirationMonth(customerData);
            SetCustomerCreditCardExpirationYear(customerData);
        }

        private void SetCustomerCreditCardExpirationYear(User customerData)
            => SetText(WindowInputLocator("year"), customerData.ExpirationYear);

        private void SetCustomerCreditCardExpirationMonth(User customerData)
            => SetText(WindowInputLocator("month"), customerData.ExpirationMonth);

        internal int GetTotalAmountFromOrderWindow()
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            return int.Parse(GetTextOfElement(TotalAmountLocator).Substring(7));
        }

        private void SetCustomerCity(User customerData)
            => SetText(WindowInputLocator("city"), customerData.City);

        private void SetCustomerCountry(User customerData)
            => SetText(WindowInputLocator("country"), customerData.Country);

        private void SetCustomerCreditCard(User customerData)
            => SetText(WindowInputLocator("card"), customerData.CreditCardNumber);

        internal bool IsEnterRequiredDataAlertShowed()
            => Alert.IsBrowserAlertContainsExpectedMessage(EnterRequiredDataAlert);

        public void SetCustomerName(User customerData)
            => SetText(WindowInputLocator("name"), customerData.Name);

        public override string CurrentWindowId => "#orderModal";

        public override string WindowSubmitAction => "purchaseOrder()";

        public string EnterRequiredDataAlert => "Please fill out Name and Creditcard.";

        public By TotalAmountLocator => By.Id("totalm");
    }
}