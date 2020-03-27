using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

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
            Reporter.LogPassingTestStep($"Form has been filled out using customer data: {customerData.Name}");
        }

        internal int GetTotalAmountFromOrderWindow()
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            return int.Parse(GetTextOfElement(TotalAmountLocator).Substring(7));
        }

        internal bool IsEnterRequiredDataAlertShowed() => IsAlertShowed(AlertType.EnterRequiredDataAlert);

        private void SetCustomerName(User customerData)
            => SetText(WindowInputLocator("name"), customerData.Name);
        private void SetCustomerCity(User customerData)
            => SetText(WindowInputLocator("city"), customerData.City);
        private void SetCustomerCountry(User customerData)
            => SetText(WindowInputLocator("country"), customerData.Country);
        private void SetCustomerCreditCard(User customerData)
            => SetText(WindowInputLocator("card"), customerData.CreditCardNumber);
        private void SetCustomerCreditCardExpirationYear(User customerData)
            => SetText(WindowInputLocator("year"), customerData.ExpirationYear);
        private void SetCustomerCreditCardExpirationMonth(User customerData)
            => SetText(WindowInputLocator("month"), customerData.ExpirationMonth);

        public override string CurrentWindowId => "#orderModal";
        public override string WindowSubmitAction => "purchaseOrder()";

        public By TotalAmountLocator => By.Id("totalm");
    }
}