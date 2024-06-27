using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_Driver.WrapperFactory;
using System;

namespace Selenium_Driver.Basics
{
    public static class DriverStepsAction
    {
        private static IWebDriver _driver = DriverStepsFactory.driver;

        #region When

        public static void QuandoAcionadoOBotao(string nomeBotao)
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    foreach (IWebElement element in _driver.FindElements(By.ClassName("selenium-button")))
                        if (element.Text.Contains(nomeBotao))
                        {
                            element.Click();
                            return;
                        }
                }
                catch { }
            }
            throw new NullReferenceException("botão " + nomeBotao + " não encontrado");
        }

        #endregion

        private static void DadoOScrollAteOBotao(IWebElement element)
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;

            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            return;
        }
    }
}