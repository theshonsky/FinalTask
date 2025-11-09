using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using OpenQA.Selenium;

namespace FinalTask.BusinesLayer.PageObjects
{
    internal class LoginPage
    {
        private WebDriverWrapper driver;

        public LoginPage(WebDriverWrapper driver)
        {
            this.driver = driver;
        }

        private readonly By userNameLocator = By.CssSelector("input[data-test='username']");
        private readonly By passwordLocator = By.CssSelector("input[data-test='password']"); 
        private readonly By loginButtonLocator = By.CssSelector("input[data-test='login-button']");
        private readonly By errorText = By.CssSelector("h3[data-test='error']");

        public MainPage Login(string username, string password)
        {
            driver.EnterText(userNameLocator, username);
            driver.EnterText(passwordLocator, password);
            driver.Click(loginButtonLocator);

            return new MainPage(driver);
        }
        public void LoginUsernameOnly(string username, string password)
        {
            driver.EnterText(userNameLocator, username);
            driver.EnterText(passwordLocator, password);
            driver.ClearText(passwordLocator);
            driver.Click(loginButtonLocator);
        }

        public void LoginPasswordOnly(string username, string password)
        {
            driver.EnterText(userNameLocator, username);
            driver.EnterText(passwordLocator, password);
            driver.ClearText(userNameLocator);
            driver.Click(loginButtonLocator);
        }

        public void SubmitWithEmptyCredentials(string username, string password)
        {
            driver.EnterText(userNameLocator, username);
            driver.EnterText(passwordLocator, password);
            driver.ClearText(userNameLocator);
            driver.ClearText(passwordLocator);
            driver.Click(loginButtonLocator);
        }

        public string GetErrorText()
        {
            return driver.GetText(errorText);
        }
    }
}
