***Connection String está no diretorio***
	LocadoraS2IT.Shared.Runtime

***Usuario Inicial***
	Login: master@s2it.com.br
	Senha: Senh@123*

***Comandos Migrations***

*Inicia o migration
	-Enable-Migrations
*Cria(versiona) uma instância do migration
	-Add-Migration {v1}
*Atualiza a base de dados
	-Update-Database

***Iniciando o projeto***
	-Primeiro voce deve configurar a Connection String valida para o banco se gerado.
	-Rodar Comandos do Migration no Package Manager Console da Camada de DATA
	-Rodar no banco criado o Script que esta dentro do repositorio com o nome 'LOCADORAS2ITCREATEMASTER'
	-Logar com o Usuario Inicial


***Manual do projeto***
	-Ao criar um novo amigo voce esta gerando um novo usuario baseado no email que foi passado, a senha sera gerada como padrao 'Senh@123*' (esta no web config a chave), voce pode alterar a senha depois no gerenciamento de conta.
	-Para inserir um jogo voce deve inserir um genero primeiro.


***Comentario do projeto***
	-O foco do projeto foi mostrar a estruturação do mesmo nao se importando com o layout da camada web.(Mesmo assim tentei deixar em PT-BR)
	-Usei alguns conceitos mistos de CQRS SOLID DDD entre outros.
	-Foram feitas a Injeção de dependencia para que o sistema tivesse uma estrutura pronta para um futuro crescimento sem impactos em sua fundamentação.
	

