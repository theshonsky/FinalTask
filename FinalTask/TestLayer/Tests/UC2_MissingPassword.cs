using FinalTask.BusinesLayer.PageObjects;
using FinalTask.CoreLayer;
using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using FluentAssertions;
using log4net;

namespace FinalTask.TestLayer.Tests
{
    public class UC2_MissingPassword : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UC2_MissingPassword));
        private readonly WebDriverWrapper browser;

        public UC2_MissingPassword()
        {
            var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Config.BrowserType);
            browser = new WebDriverWrapper(browserType);
            browser.StartBrowser(Config.implicitWaitTime);
            browser.NavigateTo(Config.AppUrl);
        }

        [Fact]
        public void InvalidLogin_ShouldDisplayPassRequirment()
        {
            log.Info($"Test UC2 start point");

            LoginPage loginPage = new LoginPage(browser);
            string errorText = "Epic sadface: Password is required";

            loginPage.LoginUsernameOnly("standard_user", "secret_sauce");
            log.Info($"UC2 InputSubmitted");

            loginPage.GetErrorText().Should().Be(errorText);
            log.Info($"Test UC2 passed");
        }

        public void Dispose()
        {
            browser?.Close();
        }
    }
}
