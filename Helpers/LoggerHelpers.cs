using ReportingLibrary;

namespace demoblaze_selenium_csharp.Helpers
{
    public static class LoggerHelpers
    {
        public static void LogInfoAboutAlertShowed(bool testStepResult)
        {
            Reporter.LogTestStep(
                testStepResult,
                "Browser alert containing expected message has been displayed",
                "Browser alert containing expected message has not been displayed"
                );
        }

        public static void LogInfoAboutPageOrWindowOpening(string windowOrPageName)
        {
            Reporter.LogPassingTestStep($"Opening {windowOrPageName}");
        }

        public static void LogInfoAboutPageOrWindowOpened(bool testStepResult, string windowOrPageName)
        {
            Reporter.LogTestStep(
                testStepResult,
                $"{windowOrPageName} has been opened successfully",
                $"{windowOrPageName} has not been opened"
                );
        }

        public static void LogInfoAboutWindowSubmitted(string windowName)
        {
            Reporter.LogPassingTestStep($"{windowName} has been submitted");
        }

        public static void LogInfoAboutProductAddedToCart(bool testStepResult, string productName)
        {
            Reporter.LogTestStep(
                testStepResult,
                $"Product \"{productName}\" has been added successfully to the cart",
                $"Product \"{productName}\" has not been added to the cart"
                );
        }

        public static void LogInfoAboutProductRemovedFromCart(bool testStepResult, string productName)
        {
            Reporter.LogTestStep(
                testStepResult,
                $"Product \"{productName}\" has been removed successfully from the cart",
                $"Product \"{productName}\" has not been removed from the cart"
                );
        }

        public static void LogInfoAboutWindowClosed(bool testStepResult, string windowName)
        {
            Reporter.LogTestStep(
                testStepResult,
                $"{windowName} has been closed successfully",
                $"{windowName} has not been closed"
                );
        }

        public static void LogInfoAboutEnteredUserData(string infoType, string userData)
        {
            Reporter.LogPassingTestStep($"User {infoType} has been successfully set to \"{userData}\"");
        }
    }
}
