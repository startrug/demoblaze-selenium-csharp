using demoblaze_selenium_csharp.Helpers;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public abstract class BaseWindow : BasePage
    {
        public BaseWindow(IWebDriver driver) : base(driver)
        {
            Alert = new Alerts(driver);
        }

        public virtual void FillOutForm(UserData contactFormData)
        {
            WaitForElementVisibility(CurrentWindowLocator);
            SetInputValues(contactFormData);
            Click(SubmitWindowButtonLocator);
            WaitForBrowserAlert();
        }

        public virtual void SetInputValues(UserData contactFormData) { }

        public virtual void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public virtual bool IsWindowOpened() => IsElementDisplayed(CurrentWindowLocator);
        public virtual bool IsWindowClosed() => IsElementDisplayed(CurrentWindowLocator);

        public virtual By CloseWindowButton => By.CssSelector($"{CurrentWindowId} [class='close']");
        public virtual By CurrentWindowLocator => By.CssSelector($"{CurrentWindowId}[role='dialog']");
        public virtual By SubmitWindowButtonLocator => By.CssSelector($"[onclick='{WindowSubmitAction}']");

        public virtual string WindowSubmitAction {get; set;}

        public virtual string CurrentWindowId { get; set; }

        public Alerts Alert { get; set; }
    }
}