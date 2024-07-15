#language: pt-BR
Funcionalidade: Validar testes para login

Contexto:
	Dado que estou na tela "Home"
	Quando seleciono o menu "Acessar minha conta"
	Então deve ser exibido os campos para login
	
Cenário: Validar mensagem para Login inválido
	Quando preencho os dados de login "rafaeltulio@gmail.com" e senha "123abc@"
	E seleciono o botão "Entrar"
	Então deve ser exibido mensagem de alerta "E-mail ou senha inválidos"

Cenário: Validar erro para campo email inválido
	Quando preencho os dados de login " " e senha "123abc@"
	E seleciono o botão "Entrar/Disable"
	Então devo validar o campo "email" está incorreto
	
Cenário: Validar erro para campo email senha
	Quando preencho os dados de login "teste@gmail.com" e senha ""
	E seleciono o botão "Entrar/Disable"
	Então devo validar o campo "password" está incorreto

Cenário: Validar esqueceu a senha	
	Quando preencho os dados de login "teste@senha.com" e senha "123@abc"
	E seleciono o botão "Esqueceu a senha?"
	Então valido que estou na tela esqueci a senha
	
