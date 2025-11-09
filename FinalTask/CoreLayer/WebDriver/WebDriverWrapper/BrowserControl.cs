using log4net;
using OpenQA.Selenium;

namespace FinalTask.CoreLayer.WebDriver.WebDriverWrapper
{
    internal partial class WebDriverWrapper
    {
        private readonly TimeSpan timeout;

        private readonly IWebDriver driver;

        private const int WaitTimeInSeconds = 5;

        private readonly ILog log = LogManager.GetLogger(typeof(WebDriverWrapper));

        public WebDriverWrapper(BrowserType browserType)
        {
            driver = BrowserFactory.CreateWebDriver(browserType);
            timeout = TimeSpan.FromSeconds(WaitTimeInSeconds);
        }

        public void StartBrowser(int implicitWaitTime)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
        }
        public void Close()
        {
            driver.Quit();
        }
        public void NavigateTo(string url)
        {
            log.Info($"Navigating to URL: {url}");
            driver.Navigate().GoToUrl(url);
        }

        public string GetUrl()
        {
            return driver.Url;
        }

        
    }
}
