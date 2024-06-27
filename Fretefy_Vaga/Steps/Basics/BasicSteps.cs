using Selenium_Driver.Basics;
using TechTalk.SpecFlow;

namespace Fretefy_Vaga.Steps
{
    [Binding]
    public sealed class BasicSteps
    {
        static void Main(string[] args)
        { }

        #region Wait

        [When(@"aguardar o carregamento da tela ""(.*)""")]
        [When(@"aguardar o carregamento da página ""(.*)""")]
        public void QuandoAguardarOCarregamentoDaPagina(string breadcrumbHead)
        {
            DriverStepsWait.WaitPageLoaded(breadcrumbHead,500);
        }

        [When(@"aguardar o carregamento da URL ""(.*)""")]
        public void QuandoAguardarOCarregamentoDaUrl(string url)
        {
            DriverStepsWait.WaitPageLoaded(url);
        }

        #endregion    
    }
}