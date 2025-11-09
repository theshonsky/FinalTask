using FinalTask.BusinesLayer.PageObjects;
using FinalTask.CoreLayer;
using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using FluentAssertions;
using log4net;
using System.Security.Policy;

namespace FinalTask.TestLayer.Tests
{
    public class UC1_EmptyLogin : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UC1_EmptyLogin));
        private readonly WebDriverWrapper browser;

        public UC1_EmptyLogin()
        {
            var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Config.BrowserType);
            browser = new WebDriverWrapper(browserType);
            browser.StartBrowser(Config.implicitWaitTime);
            browser.NavigateTo(Config.AppUrl);
        }

        [Fact]
        public void InvalidLogin_ShouldDisplayNameRequirment()
        {
            log.Info($"Test UC1 start point");

            LoginPage loginPage = new LoginPage(browser);
            string errorText = "Epic sadface: Username is required";

            loginPage.SubmitWithEmptyCredentials("standard_user", "secret_sauce");
            log.Info($"UC1 InputSubmitted");

            loginPage.GetErrorText().Should().Be(errorText);
            log.Info($"Test UC1 passed");
        }

        public void Dispose()
        {
            browser?.Close();
        }
    }
}
