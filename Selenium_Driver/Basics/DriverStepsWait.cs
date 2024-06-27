using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_Driver.WrapperFactory;
using System.Threading;

namespace Selenium_Driver.Basics
{
    public static class DriverStepsWait
    {
        private static IWebDriver _driver = DriverStepsFactory.driver;

        #region Wait
                
        public static void WaitPageLoaded(string url)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (_driver.Url.Contains(url))
                    Thread.Sleep(500);
            }
        }

        public static void WaitPageLoaded(string breadcrumbHead, int sleep = 500)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(TimeoutException));

            try
            {
                if (_driver.FindElement(By.ClassName("float-panel__header")).FindElement(By.ClassName("title")).Text.Contains(breadcrumbHead))
                    return;
            }
            catch
            {
                Thread.Sleep(sleep);
            }
        }
        
        #endregion
    }
}
