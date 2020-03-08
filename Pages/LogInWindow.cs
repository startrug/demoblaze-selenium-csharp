﻿using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class LogInWindow : BaseWindow
    {
        public LogInWindow(IWebDriver driver) : base(driver) { }

        public override bool IsWindowOpened() => WaitForElementVisibility(CurrentWindowLocator);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowButton);
            Click(CloseWindowButton);
        }

        public override string CurrentWindowId => "[id='logInModal']";
    }
}