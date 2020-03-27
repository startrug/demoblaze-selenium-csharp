using ReportingLibrary;

namespace demoblaze_selenium_csharp.Helpers
{
    public static class LoggerHelpers
    {
        public static void LogInfoAboutAlertShowed(bool testStepResult)
        {
            Reporter.LogTestStep(
                testStepResult,
                "Browser alert has been displayed and submitted",
                "Browser alert has not been displayed"
                );
        }

        public static void LogInfoAboutOpenedPageOrWindow(string pageTitle)
        {
            Reporter.LogPassingTestStep($"{pageTitle} has been opened successfully");
        }
    }
}
