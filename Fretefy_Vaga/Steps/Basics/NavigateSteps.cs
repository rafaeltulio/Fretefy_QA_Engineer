using Selenium_Driver.Basics;
using System.Configuration;
using System.Security.Policy;
using TechTalk.SpecFlow;
 
namespace Fretefy_Vaga.Steps
{
    [Binding]
    public sealed class NavigateSteps
    {
        public static string scenarioPrimeiro;

        #region Given

        [Given(@"a URL ""([^\""]*)""")]
        [Given(@"a tela atrav[ée]s da URL ""([^\""]*)""")]
        public void DadoATelaAtravesDaURL(string URL)
        {
            DriverStepsNavigate.DadoATelaAtravesDaURL(URL);
        }

        #endregion

        #region When

        [When(@"voltar para tela anterior")]
        [When(@"retornar a tela anterior")]
        public void QuandoRetornarATelaAnterior()
        {
            DriverStepsNavigate.QuandoRetornarATelaAnterior();
        }

        [When(@"atualizar a página")]
        [When(@"atualizado a página")]
        public void QuandoAtualizadoAPagina()
        {
            DriverStepsNavigate.QuandoAtualizadoAPagina();
        }

        [When(@"ir para a tela posterior")]
        public void QuandoIrParaATelaPosterior()
        {
            DriverStepsNavigate.QuandoIrParaATelaPosterior();
        }

        #endregion

        #region Then

        [Then(@"a url da p[áa]gina deve ser ""([^\""]*)""")]
        [Then(@"a URL da p[áa]gina deve ser ""([^\""]*)""")]
        public void EntaoAURLDaPaginaDeveSer(string URL)
        {
            DriverStepsNavigate.EntaoAURLDaPaginaDeveSer(URL);
        }

        [Then(@"a URL da p[áa]gina deve conter ""([^\""]*)""")]
        public void EntaoAURLDaPaginaDeveConter(string URL)
        {
            DriverStepsNavigate.EntaoAURLDaPaginaDeveConter(URL);
        }

        [Then(@"deve ser aberto a página com a URL ""([^\""]*)""")]
        public void EntaoDeveSerAbertoAPaginaComAURL(string URL)
        {
            DriverStepsNavigate.EntaoDeveAbrirEmOutraAbaOLink(URL);
        }
        
        [Then(@"deve abrir em outra aba o link ""([^\""]*)""")]
        public void EntaoDeveAbrirEmOutraAbaOLink(string link)
        {
            DriverStepsNavigate.EntaoDeveAbrirEmOutraAbaOLink(link);
        }

        [Given(@"o scroll até o botão ""(.*)""")]
        public void DadoOScrollAteOBotao(string nomeBotao)
        {
            DriverStepsNavigate.DadoOScrollAteOBotao(nomeBotao);
        }
        
        #endregion

    }
}