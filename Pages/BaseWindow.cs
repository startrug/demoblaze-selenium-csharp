using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public abstract class BaseWindow : BasePage
    {
        public BaseWindow(IWebDriver driver) : base(driver) { }

        public virtual void FillOutFormWithBrowserAlert(CustomerData contactFormData)
        {
            IsElementDisplayedAfterWaiting(CurrentWindowLocator);
            SetInputValues(contactFormData);
            Click(SubmitWindowButtonLocator);
            WaitForBrowserAlert();
        }

        public virtual void SetInputValues(CustomerData contactFormData) { }

        public virtual void ClickCloseWindow()
        {
            IsElementDisplayedAfterWaiting(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public virtual bool IsWindowOpened() => IsElementDisplayedImmediately(CurrentWindowLocator);
        public virtual bool IsWindowClosed() => IsElementDisplayedImmediately(CurrentWindowLocator);

        public virtual By CloseWindowButton => By.CssSelector($"{CurrentWindowId} .close");
        public virtual By CurrentWindowLocator => By.CssSelector($"{CurrentWindowId} .modal-content");
        public virtual By SubmitWindowButtonLocator => By.CssSelector($"[onclick='{WindowSubmitAction}']");

        public virtual string WindowSubmitAction {get; set;}

        public virtual string CurrentWindowId { get; set; }
    }
}