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
    }
}