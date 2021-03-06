using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.version2
{
    public abstract class WebPage
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 60;

        public WebPage(IWebDriver _driver)
        {
            Driver = _driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait WebDriverWait { get; set; }
        protected virtual string Url => "http://automationpractice.com/";

        protected void HoverElement(IWebElement iwebElement)
        {
            var actions = new Actions(Driver);

            actions.MoveToElement(iwebElement).Perform();
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageToLoad();
        }

        protected virtual void WaitForPageToLoad()
        {
        }

        protected void SwitchToFrame(string frameId)
        {
            try
            {
                Driver.SwitchTo().Frame(Driver.FindElement(By.XPath(frameId)));
            }
            catch (Exception)
            {
                throw new Exception("Invalid frame");
            }
        }

        public void ScrollToElement(IWebElement elementToScrollTo)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", elementToScrollTo);
        }

        public void WaitUntilElementIsClickable(IWebElement elementToBeClickable)
        {
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(elementToBeClickable));
        }

        protected IWebElement WaitAndFindElement(By by)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitForAjax()
        {
            WebDriverWait.Until(wd => ((IJavaScriptExecutor)Driver).ExecuteScript("return jQuery.active").ToString() == "0");
        }

        public void WaitUntilPageLoadsCompletely()
        {
            WebDriverWait.Until(wd => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
