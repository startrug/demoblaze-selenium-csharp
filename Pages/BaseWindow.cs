using demoblaze_selenium_csharp.Models;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public abstract class BaseWindow : BasePage
    {
        public BaseWindow(IWebDriver driver) : base(driver) { }

        public By WindowInputLocator(string id) => By.Id($"{id}");

        public virtual void FillOutFormWithBrowserAlert(User customerData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(customerData);
            Click(SubmitWindowButtonLocator);
            WaitForBrowserAlert();
        }

        public virtual void SetInputValues(User userData)
        {
            SetUserName(userData);
            SetUserPassword(userData);
            SetUserEmail(userData);
            SetUserMessage(userData);
            SetUserCountry(userData);
            SetUserCity(userData);
            SetUserCreditCard(userData);
            SetUserCreditCardExpirationMonth(userData);
            SetUserCreditCardExpirationYear(userData);
        }
        public virtual void SubmitWindow()
        {
            ClickOnElementAfterWaiting(SubmitWindowButtonLocator);
        }

        public virtual void SetUserEmail(User userData) { }
        public virtual void SetUserPassword(User userData) { }
        public virtual void SetUserName(User userData) { }
        public virtual void SetUserMessage(User userData) { }
        public virtual void SetUserCountry(User userData) { }
        public virtual void SetUserCity(User userData) { }
        public virtual void SetUserCreditCard(User userData) { }
        public virtual void SetUserCreditCardExpirationMonth(User userData) { }
        public virtual void SetUserCreditCardExpirationYear(User userData) { }

        public virtual void ClickCloseWindow()
        {
            IsElementDisplayedAfterWaiting(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public virtual bool IsWindowOpened() => IsElementDisplayedAfterWaiting(CurrentWindowLocator);

        public virtual bool IsWindowClosed() => IsElementDisplayedImmediately(CurrentWindowLocator);

        public virtual By CloseWindowButton => By.CssSelector($"{CurrentWindowId} .close");
        public virtual By CurrentWindowLocator => By.CssSelector($"{CurrentWindowId} .modal-content");
        public virtual By SubmitWindowButtonLocator => By.CssSelector($"[onclick='{WindowSubmitAction}']");

        public virtual string WindowSubmitAction {get; set;}
        public virtual string CurrentWindowId { get; set; }
        public virtual string CurrentWindowName { get; set; }
    }
}