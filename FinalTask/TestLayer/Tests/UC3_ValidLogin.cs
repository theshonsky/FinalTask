using FinalTask.BusinesLayer.PageObjects;
using FinalTask.CoreLayer;
using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using FluentAssertions;
using log4net;

namespace FinalTask.TestLayer.Tests
{
    public class UC3_ValidLogin : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UC3_ValidLogin));
        private readonly WebDriverWrapper browser;

        public UC3_ValidLogin()
        {
            var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Config.BrowserType);
            browser = new WebDriverWrapper(browserType);
            browser.StartBrowser(Config.implicitWaitTime);
            browser.NavigateTo(Config.AppUrl);
        }
        public static IEnumerable<object[]> ValidCredentials => new List<object[]>
        {
            new object[] { "standard_user", "secret_sauce" },
            new object[] { "problem_user", "secret_sauce" },
            new object[] { "performance_glitch_user", "secret_sauce" }
        };

        [Theory]
        [MemberData(nameof(ValidCredentials))]
        public void ValidLogin_ShouldDisplayCorrectLogo(string username, string password)
        {
            log.Info($"Test UC3 start point");

            string logoText = "Swag Labs";

            var loginPage = new LoginPage(browser);
            var mainPage = loginPage.Login(username, password);
            log.Info($"User logged in");

            mainPage.GetLogoText().Should().Be(logoText);
            log.Info($"Test UC3 passed");

            browser.NavigateTo(Config.AppUrl);
        }

        public void Dispose()
        {
            browser?.Close();
        }
    }
}
