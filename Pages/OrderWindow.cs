using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class OrderWindow : BaseWindow
    {
        public OrderWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public PurchaseAlert FillOutFormAndPurchase(UserData userFormData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(userFormData);
            Click(SubmitWindowButtonLocator);
            return new PurchaseAlert(Driver);
        }

        public override void SetInputValues(UserData userData)
        {
            SetUserName(userData);
            SetUserCreditCard(userData);
        }

        private void SetUserCreditCard(UserData userData)
            => SetText(UserCreditCardInputLocator, userData.CreditCardNumber);

        public void SetUserName(UserData userData)
            => SetText(OrderUserNameInputLocator, userData.Name);

        public override string CurrentWindowId => "#orderModal";

        public By OrderUserNameInputLocator => By.Id("name");
        public By UserCreditCardInputLocator => By.Id("card");

        public override string WindowSubmitAction => "purchaseOrder()";
    }
}