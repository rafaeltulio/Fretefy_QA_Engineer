using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium_Driver.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Fretefy_Vaga.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        #region Given
        [Given(@"que estou na tela ""([^""]*)""")]
        public void AcessoATela(string tituloPage)
        {
            DriverStepsNavigate.ValidarTituloPage(tituloPage);
        }
        #endregion

        #region When
        [When(@"seleciono o menu ""([^""]*)""")]
        public void SelecionarMenu(string nomeMenu)
        {
            DriverStepsAction.QuandoAcionadoMenu(nomeMenu);
        }

        [When(@"preencho os dados de login ""([^""]*)"" e senha ""([^""]*)""")]
        public void PreencherDadosLogin(string email, string senha)
        {
            DriverStepsAction.PreencherCamposLogin(email, senha);
        }

        [When(@"seleciono o botão ""([^""]*)""")]
        public void SelecionarBotao(string nomeBotao)
        {
            DriverStepsAction.ClicarBotao(nomeBotao);
        }

        #endregion

        #region Then
        [Then(@"deve ser exibido os campos para login")]
        public void ExibirFormLogin()
        {
            DriverStepsAction.ValidarFormLogin();

        }

        [Then(@"deve ser exibido mensagem de alerta ""([^""]*)""")]
        public void ExibirMensagemAlerta(string msgmAlerta)
        {
            DriverStepsAction.ValidarMensagem(msgmAlerta);  
        }

        [Then(@"devo validar o campo ""([^""]*)"" está incorreto")]
        public void ValidarCampoIncorreto(string nomeCampo)
        {
            DriverStepsAction.ValidarErroCampo(nomeCampo);
            
        }

        [Then(@"valido que estou na tela esqueci a senha")]
        public void EsqueciMinhaSenha()
        {
            DriverStepsAction.ValidarTelaSenha();
        }


        #endregion
    }
}
