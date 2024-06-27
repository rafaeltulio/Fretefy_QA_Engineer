using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_Driver.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Selenium_Driver.Basics
{
    public static class DriverStepsNavigate
    {
        private static IWebDriver _driver = DriverStepsFactory.driver;

        #region Given

        public static void DadoATelaAtravesDaURL(string URL)
        {
            for (int i = 0; !_driver.Url.Contains(URL) && i <= 5; i++)
            {
                try
                {
                    _driver.Url = ConfigurationManager.AppSettings["URL"] + "#/" + URL;
                    return;
                }
                catch
                {
                }
            }
            _driver.Url = ConfigurationManager.AppSettings["URL"] + "#/" + URL;
        }

        public static void DadoAURL(string URL)
        {
            for (int i = 0; !_driver.Url.Contains(URL) && i <= 5; i++)
            {
                try
                {
                    _driver.Url = URL;

                    return;
                }
                catch
                {
                }
            }
            _driver.Url = URL;
        }

        #endregion

        #region When

        public static void QuandoRetornarATelaAnterior()
        {
            _driver.Navigate().Back();
        }

        public static void QuandoAtualizadoAPagina()
        {
            Actions actionObject = new Actions(_driver);
            actionObject.KeyDown(Keys.Control).SendKeys(Keys.F5).KeyUp(Keys.Control).Perform();

            _driver.FindElement(By.TagName("html")).SendKeys(Keys.Control + Keys.Shift + "r");

            _driver.Navigate().Refresh();
        }

        public static void QuandoIrParaATelaPosterior()
        {
            _driver.Navigate().Forward();
        }

        #endregion

        #region Then
                
        public static void EntaoAURLDaPaginaDeveSer(string link, bool URLplataforma = true)
        {
            var url = RetornaURLAtual();

            for (int i = 0; i <= 10; i++)
            {
                if (url.Contains(link))
                    break;

                url = RetornaURLAtual();
                i++;
            }

            if (URLplataforma)
                Assert.AreEqual(ConfigurationManager.AppSettings["URL"] + link, url);
            else
                Assert.AreEqual(link, url);
        }

        public static void EntaoAURLDaPaginaDeveConter(string link)
        {
            var url = RetornaURLAtual();

            for (int i = 0; i <= 20; i++)
            {
                if (url.ToLower().Contains(link.ToLower()))
                    break;

                url = RetornaURLAtual();
            }

            Assert.IsTrue(url.ToLower().Contains(link.ToLower()), "Url atual: " + url + ". é diferente da esperada: " + link + "");
        }

        public static void EntaoDeveAbrirEmOutraAbaOLink(string link)
        {
            var url = RetornaURLAba(link);

            Assert.AreEqual(true, url.Contains(link), "url atual é " + url + "");
        }

        public static void DadoOScrollAteOBotao(string nomeBotao)
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;

            foreach (var form in _driver.FindElements(By.ClassName("mat-button-wrapper")))
            {
                if (form.Text == nomeBotao)
                {
                    jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", form);
                    return;
                }
            }
            foreach (var form in _driver.FindElements(By.TagName("button")))
            {
                if (form.Text == nomeBotao)
                {
                    jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", form);
                    return;
                }
            }

            throw new NullReferenceException("Botão " + nomeBotao + " não encontrado");
        }

        #endregion

        #region genericos

        public static string RetornaURLAtual()
        {
            return DriverStepsFactory.driver.Url;
        }

        public static string RetornaURLAba(string urlReferencia = "")
        {
            string paginaAtual = _driver.CurrentWindowHandle;

            var pages = _driver. WindowHandles.ToList();

            for (int i = 0; i <= 20; i++)
            {     
                if (pages.Count == 2)
                    break;
          
                pages = _driver.WindowHandles.ToList();                                
            }
            foreach (var pagina in pages)
            {
                if (pagina != paginaAtual)
                {
                    try
                    {
                        _driver.SwitchTo().Window(pagina);
                        string url = DriverStepsFactory.driver.Url;

                        if (url.Contains("about"))
                            url = DriverStepsFactory.driver.Url;
                        if (url.Contains(urlReferencia) || url == "")
                        {
                            _driver.Close();

                            _driver.SwitchTo().Window(paginaAtual);
                            return url;
                        }

                        _driver.Close();
                        _driver.SwitchTo().Window(paginaAtual);
                    }
                    catch
                    {
                        Console.WriteLine("Não havia outra aba aberta para " + urlReferencia);
                    }
                }
            }
            return DriverStepsFactory.driver.Url;
        }

        public static void TrocaAba()
        {
            string paginaAtual = _driver.CurrentWindowHandle;

            foreach (var pagina in _driver.WindowHandles.ToList())
            {
                if (pagina != paginaAtual)
                {
                    _driver.SwitchTo().Window(pagina);

                    return;
                }
            }

            throw new NullReferenceException("Não havia outra aba aberta");
        }

        public static void TrocaAba(string pagina)
        {
            List<string> lstWindow = _driver.WindowHandles.ToList();

            foreach (var paginas in _driver.WindowHandles.ToList())
            {
                if (paginas != pagina)
                {
                    _driver.SwitchTo().Window(pagina);

                    return;
                }
            }
            throw new NullReferenceException("Não havia outra aba aberta");
        }

        public static void MantemSomenteAbaPrincipal()
        {
            string paginaAtual = _driver.CurrentWindowHandle;
            List<string> lstWindow = _driver.WindowHandles.ToList();

            foreach (var pagina in _driver.WindowHandles.ToList())
            {
                if (pagina != paginaAtual)
                    _driver.SwitchTo().Window(pagina).Close();
            }

            _driver.SwitchTo().Window(paginaAtual);
        }
        
        #endregion
    }
}