using Fretefy_Vaga.Hooks;
using Selenium_Driver.Basics;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
 
namespace Fretefy_Vaga.Steps
{
    [Binding]
    public sealed class ValueSteps
    {
        #region Given

        [Given(@"os valores para os campos")]
        public void DadoOsValoresParaOsCampos(Table table)
        {
            foreach (var Rows in table.Rows)
            {
                foreach (var nomeCampo in Rows.Keys)
                {
                    var valorCampo = Rows[nomeCampo];

                    DadoOValorParaOCampo(valorCampo, nomeCampo);
                }
            }
        }

        [Given(@"o valor ""([^\""]*)"" para o campo ""([^\""]*)""")]
        public void DadoOValorParaOCampo(string valorCampo, string nomeCampo)
        {
            DriverStepsValue.DadoOValorParaOCampo(nomeCampo, valorCampo);
        }

        #endregion

        #region Then

        #endregion

    }
}