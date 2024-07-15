using TechTalk.SpecFlow;
using Selenium_Driver.WrapperFactory;
using Fretefy_Vaga.Steps;
using System.Configuration;

namespace Fretefy_Vaga.Hooks
{
    [Binding]
    public sealed class BasicHooks
    {
        static NavigateSteps navSteps = new NavigateSteps();
        public static string featureAtual;

        [BeforeScenario]
        public static void AssemblyInitialize()
        {
            DriverStepsFactory.InitBrowser(ConfigurationManager.AppSettings["Browser"].ToUpper(), ConfigurationManager.AppSettings["ModoOculto"].ToUpper());

            navSteps.DadoATelaAtravesDaURL(ConfigurationManager.AppSettings["URL"]);
        }

        [AfterScenario]
        public static void AfterRunner()
        {
            DriverStepsFactory.CloseAllDrivers();
        }
    }
}