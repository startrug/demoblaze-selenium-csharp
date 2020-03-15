using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class OrderWindow : BaseWindow
    {
        public OrderWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public PurchaseAlert FillOutFormAndPurchase(CustomerData customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);
            return new PurchaseAlert(Driver);
        }

        public override void SetInputValues(CustomerData customerData)
        {
            SetCustomerName(customerData);
            SetCustomerCountry(customerData);
            SetCustomerCity(customerData);
            SetCustomerCreditCard(customerData);
            SetCustomerCreditCardExpirationMonth(customerData);
            SetCustomerCreditCardExpirationYear(customerData);
        }

        private By OrderInputLocator(string id) => By.Id($"{id}");

        private void SetCustomerCreditCardExpirationYear(CustomerData customerData)
            => SetText(OrderInputLocator("year"), customerData.ExpirationYear);

        private void SetCustomerCreditCardExpirationMonth(CustomerData customerData)
            => SetText(OrderInputLocator("month"), customerData.ExpirationMonth);

        private void SetCustomerCity(CustomerData customerData)
            => SetText(OrderInputLocator("city"), customerData.City);

        private void SetCustomerCountry(CustomerData customerData)
            => SetText(OrderInputLocator("country"), customerData.Country);

        private void SetCustomerCreditCard(CustomerData customerData)
            => SetText(OrderInputLocator("card"), customerData.CreditCardNumber);

        public void SetCustomerName(CustomerData customerData)
            => SetText(OrderInputLocator("name"), customerData.Name);

        public override string CurrentWindowId => "#orderModal";

        public override string WindowSubmitAction => "purchaseOrder()";
    }
}