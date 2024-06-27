using OpenQA.Selenium;
using Selenium_Driver.WrapperFactory;

namespace Selenium_Driver.Basics
{
    public static class DriverStepsValue
    {
        static IWebElement element;

        #region Given

        public static void DadoOValorParaOCampo(string nomeCampo, string valorCampo)
        {
            IWebElement element = null;

            InsereValorEmCampo(element, valorCampo);
        }

        public static void InsereValorEmCampo(IWebElement element, string valorCampo, bool mask = false)
        {
            element.SendKeys(valorCampo);
        }

        #endregion
    }
}