#language: pt-BR
Funcionalidade: Selenium_Page_

Contexto: pré-requisitos para execução do teste
	- Teste exemplo
	
Cenário: Selenium - Navegação	
	Quando clicar no botão "MORE NEWS"
	Então a url da página deve ser "blog/"