using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_Driver.WrapperFactory;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Selenium_Driver.Basics
{
    public class DriverStepsAction
    {
        private static IWebDriver _driver = DriverStepsFactory.driver;
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

        public static void QuandoAcionadoMenu(string nomeMenu)
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    foreach (IWebElement element in _driver.FindElements(By.XPath("//div[contains(@class, 'button-text inverted')]")))
                        if (element.Text.Contains(nomeMenu))
                        {
                            element.Click();
                            return;
                        }
                }
                catch { }
            }
            throw new NullReferenceException("Menu " + nomeMenu + " não encontrado");
        }

        public static void ClicarBotao(string nomeBotao)
        {
            switch (nomeBotao)
            {

                case "Entrar":
                    _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                    break;

                case "Esqueceu a senha?":
                    _driver.FindElement(By.XPath("//a[@href='#/forgot-password']")).Click();
                    break;

                case "Entrar/Disable":
                    Assert.IsFalse(_driver.FindElement(By.XPath("//button[@type='submit']")).Enabled);
                    break;
                default:
                    break;
            }
        }

        public static void ValidarFormLogin()
        {
            // Aguardar um curto período de tempo para a nova aba carregar
            Thread.Sleep(3000);
            // Obter todas as abas das janelas abertas
            var janelas = _driver.WindowHandles;

            // Iterar sobre cada alça da janela
            foreach (var janela in janelas)
            {
                // Mudar para a aba da janela desejada
                if (!janela.Equals(_driver.CurrentWindowHandle))
                {
                    _driver.SwitchTo().Window(janela);
                    break;
                }
            }

            Console.WriteLine("Título da nova aba: " + _driver.Title);

            Assert.IsTrue(_driver.FindElement(By.XPath("//input[@type='email']")).Displayed);
            Assert.IsTrue(_driver.FindElement(By.XPath("//input[@type='password']")).Displayed);

        }

        public static void PreencherCamposLogin(string email, string password)
        {
            IWebElement inputLogin = _driver.FindElement(By.XPath("//input[@type='email']"));
            inputLogin.Clear();
            inputLogin.SendKeys(email);
            inputLogin.SendKeys(Keys.Tab);

            IWebElement inputSenha = _driver.FindElement(By.XPath("//input[@type='password']"));
            inputSenha.Clear();
            inputSenha.SendKeys(password);
            inputSenha.SendKeys(Keys.Tab);
        }
        public static void ValidarMensagem(string msgmAlerta)
        {
            Thread.Sleep(1000);
            string getMsgm = _driver.FindElement(By.XPath("//form[@name='loginForm']/div/ffy-alert/div")).Text;
            Console.WriteLine("Título da nova aba: " + getMsgm);

            Assert.AreEqual(msgmAlerta, getMsgm);
        }

        public static void ValidarErroCampo(string nomeCampo)
        {
            Thread.Sleep(1000);

            for (int i = 0; i < 2; i++)

            {
                try
                {
                    foreach (IWebElement element in _driver.FindElements(By.XPath("//input[@class='input__field ng-pristine ng-invalid ng-touched']")))
                        if (element.GetAttribute("type").Contains(nomeCampo))
                        {
                            Assert.AreEqual("Campo obrigatório", _driver.FindElement(By.XPath("//div[@class='helper-text']")).Text);
                            return;
                        }
                }
                catch { }
            }
            throw new NullReferenceException("o Campo " + nomeCampo + " não foi encontrado!");

        }

        public static void ValidarTelaSenha()
        {

            Thread.Sleep(1000);
            IWebElement buttonRecuperar = _driver.FindElement(By.XPath("//button[@type='submit']/span/span"));

            Assert.AreEqual("Esqueci a senha / Fretefy", _driver.Title);
            Assert.AreEqual("Esqueci a senha", _driver.FindElement(By.XPath("//h1")).Text);
            Assert.AreEqual("Recuperar senha", buttonRecuperar.Text);
            _driver.FindElement(By.XPath("//button[@icon='voltar']")).Click();
        }

    }
}