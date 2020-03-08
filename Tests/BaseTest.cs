﻿using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demoblaze_selenium_csharp.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }
        public DemoBlazeHomePage DemoBlazeHomePage { get; private set; }
        public ContactWindow ContactWindow { get; set; }
        public AboutUsWindow AboutUsWindow { get; set; }
        public CartPage CartPage { get; set; }
        public LogInWindow LogInWindow { get; set; }
        public SignUpWindow SignUpWindow { get; set; }
        public UserData TestUserData { get; private set; }
        public UserData TestUserWithMissingData { get; private set; }

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            TestUserData = new UserData("anowak@poczta.pl", "Anna Nowak", "Sample message", "Test123!");
            TestUserWithMissingData = new UserData("", "", "", "");

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            DemoBlazeHomePage = new DemoBlazeHomePage(Driver);
            DemoBlazeHomePage.GoTo();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}