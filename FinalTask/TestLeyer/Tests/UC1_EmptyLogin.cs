using FinalTask.BusinesLayer.PageObjects;
using FinalTask.CoreLayer;
using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using FluentAssertions;

namespace FinalTask.TestLeyer.Tests
{
    public class UC1_EmptyLogin : IDisposable
    {
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
            LoginPage loginPage = new LoginPage(browser);
            string errorText = "Epic sadface: Username is required";

            loginPage.SubmitWithEmptyCredentials("standard_user", "secret_sauce");

            loginPage.GetErrorText().Should().Be(errorText);
        }

        public void Dispose()
        {
            browser?.Close();
        }
    }
}
