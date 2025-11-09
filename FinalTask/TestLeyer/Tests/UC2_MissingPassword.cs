using FinalTask.BusinesLayer.PageObjects;
using FinalTask.CoreLayer;
using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using FluentAssertions;

namespace FinalTask.TestLeyer.Tests
{
    public class UC2_MissingPassword : IDisposable
    {
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
            LoginPage loginPage = new LoginPage(browser);
            string errorText = "Epic sadface: Password is required";

            loginPage.LoginUsernameOnly("standard_user", "secret_sauce");

            loginPage.GetErrorText().Should().Be(errorText);
        }

        public void Dispose()
        {
            browser?.Close();
        }
    }
}
