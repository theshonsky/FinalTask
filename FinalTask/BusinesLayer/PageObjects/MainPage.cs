using FinalTask.CoreLayer.WebDriver.WebDriverWrapper;
using OpenQA.Selenium;

namespace FinalTask.BusinesLayer.PageObjects
{
    internal class MainPage
    {
        private WebDriverWrapper driver;

        public MainPage(WebDriverWrapper driver)
        {
            this.driver = driver;
        }

        private readonly By siteLogo = By.CssSelector("[data-test='header-container'] [data-test='primary-header'] .app_logo");

        public string GetLogoText()
        {
            return driver.GetText(siteLogo);
        }
    }
}
