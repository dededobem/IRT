Desafio Técnico para preenchimento de vaga no Instituto Recôncavo de Tecnologia

Sobre a aplicação (Tecnologias):

- A solução foi desenvolvida utilizando Asp.Net core 3.1 com JWT Bearer Authentication e Angular 11.
- O projeto está dividido em camadas, utilizando onion architecture e alguns design patterns como repository e DDD, aplicando e seguindo todos os princípios do SOLID e clean code.
- Foi utilizado code-first e modelos de domínio rico.
- O banco de dados usado é o Sql Server.
- Utilização de IU Swagger.

Executando a aplicação:

- Configurar no projeto IRT.Api o arquivo appsettings.json, setando a ConnectionStrings para acesso a base de dados e a SecretKey (string secreta que é usada para assinatura do token para a autenticação via JWT).
- No projeto IRT.Front, configurar a variável de ambiente "apiUrl" no arquivo environment.ts que se encontra localizado na pasta src/environments. Nesse arquivo deverá ser setado a Url da api.
- Após esses passos, executar os comandos Add-Migration "nome da migration" e Update-Database na classLibrary IRT.Infrastructure. Esses comandos deverão criar o banco de dados para rodar a aplicação.
- Após realizar todos esses passos, deverá ser acessado o seguinte endereço: "apiUrl"/swagger. Nele deverá ser criado um usuário através do endpoint /api/User.
- Por fim, no projeto IRT.Front deverá ser executado o comando "npm install", para instalar os módulos do projeto, e logo depois rodar o comando "ng server -o".
