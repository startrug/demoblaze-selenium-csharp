using demoblaze_selenium_csharp.Pages;

namespace demoblaze_selenium_csharp.Tests
{
    public class LogInBaseTest : BaseTest<LogInWindow>
    {
        protected override LogInWindow SelectTestedAppPage()
            => NavigationBar.ClickLogInLink();
    }
}
