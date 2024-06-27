using Selenium_Driver.Basics;
using TechTalk.SpecFlow;

namespace Fretefy_Vaga.Steps
{
    [Binding]
    public sealed class ActionSteps
    {        
        #region When

        [When(@"clicar no botão ""([^\""]*)""")]
        public void QuandoAcionadoOBotao(string nomeBotao)
        {
            DriverStepsAction.QuandoAcionadoOBotao(nomeBotao);
        }

        #endregion

    }
}