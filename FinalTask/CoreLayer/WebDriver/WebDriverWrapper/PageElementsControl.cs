

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.CoreLayer.WebDriver.WebDriverWrapper
{
    internal partial class WebDriverWrapper
    {
        public void Click(By by)
        {
            WaitForElementToBePresent(by)?.Click();
        }

        public void EnterText(By by, string text)
        {
            var element = WaitForElementToBePresent(by);
            element.Clear();
            element.SendKeys(text);
        }

        public void ClearText(By by)
        {
            var element = WaitForElementToBePresent(by);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }



        public IWebElement FindElement(By by)
        {
            return WaitForElementToBePresent(by);
        }

        public string GetText(By by)
        {
            var element = WaitForElementToBePresent(by);
            if (element.Displayed) 
            { 
                return element.Text; 
            }
            else 
            {
                throw new NoSuchElementException($"Element located by {by} is not displayed.");
            }
        }

        public IWebElement WaitForElementToBePresent(By by)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(drv => drv.FindElement(by));
        }

    }
}
