﻿using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

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

        public virtual void SetInputValues(User customerData) { }

        public virtual void ClickCloseWindow()
        {
            IsElementDisplayedAfterWaiting(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public virtual bool IsWindowOpened()
        {
            return IsElementDisplayedImmediately(CurrentWindowLocator);
        }

        public virtual bool IsWindowClosed() => IsElementDisplayedImmediately(CurrentWindowLocator);

        public virtual By CloseWindowButton => By.CssSelector($"{CurrentWindowId} .close");
        public virtual By CurrentWindowLocator => By.CssSelector($"{CurrentWindowId} .modal-content");
        public virtual By SubmitWindowButtonLocator => By.CssSelector($"[onclick='{WindowSubmitAction}']");

        public virtual string WindowSubmitAction {get; set;}

        public virtual string CurrentWindowId { get; set; }
    }
}