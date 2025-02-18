# LOCAR FILMS [Back-end]

### Projeto publicado: https://locarfilms.levisonjr-app.site

Locadoras de filmes fizeram parte de boa parte da minha vida, por isso resolvi trazer um pouco dessa lembrança para um projeto prático.

A parte do back-end desse projeto é o que se encontra nesse repositório.

# 📋 O projeto

Quando pensei em fazer esse projeto estabeleci algumas regras do que o projeto deveria ter para atender as necessidades de uma locadora. Por exemplo:
- Usuários separados por **administradores**, **funcionários** e **clientes**;
- Cadastro de filmes envolvendo uma **categoria** e seu **custo por dia** de aluguel;
- Um aluguel deve possuir **status** que indique seu progresso;
- Cada filme pode ser alugado por um usuário de cada vez.

# ⚙️Tecnologias utilizadas

 - C#
 - .NET / ASP.NET Core
 - Entity Framework Core (EF Core)
 - ASP.NET Identity
 - SQL Server
 - AutoMapper
 - Swagger

# 📌 Pontos abordados

 - **CRUD** de usuários, filmes e aluguéis;
 - Configuração do EF Core para a conexão com o banco de dados e de classes *models* para atender o relacionamento entre tabelas/dados;
 - Login e cadastro de usuários pelo ASP.NET Identity;
 - **Autenticação** dos usuários utilizando o **JWT**;
 -  Usuários divididos em **roles: admin, funcionário e cliente**;
 - *Endpoints* necessários passando pelo processo de **autorização** baseado na *role* do usuário;
 - Uso de *DTO's* para melhor separação entre os dados manipulados pelo *back-end* e os dados recebidos/enviados para o *front-end*;
 - Swagger para a **documentação da API**, exibindo informações úteis para o consumo, como modelos de requisição e possíveis respostas dos *endpoints*;
 - Uso de **variáveis de ambiente** para manter informações sensíveis fora do código.

# 💻Testando você mesmo

Caso queira colocar este projeto no seu computador para testar e ver em funcionamento, abra seu terminal e siga as instruções abaixo:

## Versão do .NET

Verifique que você possui instalada a versão 8 do .NET

    dotnet --version

Caso não tenha a versão necessária, visite o site https://dotnet.microsoft.com/pt-br/download da Microsoft para fazer o download.  

## Clone o repositório

Com o terminal aberto, navegue até a pasta que deseja colocar o projeto e digite:

    git clone https://github.com/Levison-Jr/locarfilms-backend.git
    cd locarfilms-backend

## Dependências

Agora já dentro da pasta do projeto, faça a restauração, ou seja, o download das dependências necessárias para conseguir executar a aplicação:

    dotnet restore

Este comando vai "trazer" para seu computador os pacotes nuget que foram utilizados, sem que seja preciso você mesmo instalar um por um.

## Banco de dados

No projeto é usado o SQL Server, então caso você ainda não tenha pode fazer o **download da versão gratuita para desenvolvedores** no link a seguir: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads.

Pode ser útil também ter o SQL Server Management Studio (SSMS) para acompanhar e gerenciar o banco de dados mais facilmente. Link de download: https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16.

Com o SQL Server instalado, agora você precisa da sua string de conexão (*connection string*) para utilizar no projeto.

> Se tiver dificuldades no download e instalação do SQL Server, SSMS, ou na obtenção da string de conexão, sugiro que assista um vídeo tutorial para se familiarizar com o processo.

Abra o projeto no seu editor de texto, como o VS Code, vá até o arquivo **appsettings.json** e substitua o valor da chave **MainConnection** com a sua string de conexão, ficando assim:

    "MainConnection": "sua_string_de_conexão_aqui"

Exemplo de connection string que pode funcionar no seu caso:

    Data Source=localhost;database=LocarFilmsDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False

O próximo passo é finalmente gerar o banco de dados através das ***migrations*** (migrações) do EF Core:

    # Caso não tenha instalado a ferramenta dotnet-ef
    dotnet tool install --global dotnet-ef
	
	# Agora pode aplicar as migrations
    dotnet ef database update
    
Com o SSMS, você pode conferir o banco de dados criado e toda a sua estrutura de tabelas.

## Variáveis de Ambiente

Vale destacar algumas das variáveis presentes no arquivo appsettings.json, como a própria string de conexão que acabamos de configurar no passo anterior.

Outras são:

 - ADMIN_EMAIL
 - ADMIN_PASSWORD
 - SecurityKey (Chave de segurança para gerar os tokens JWT)

As duas primeiras da lista são o **email e senha gerados** (caso não existam) por padrão na primeira vez que a aplicação é executada. Você pode alterar os valores para o que desejar.

A **SecurityKey** é utilizada sempre que um token JWT precisa ser gerado ou verificado. Também pode ser alterada desde que tenha 512 bits, já que o algoritmo de hash utilizado na autenticação exige esse formato.

O que elas tem em comum é que são informações sensíveis e que em determinadas situações, manter no código pode ser ruim. Logo pode ser interessante armazenar seus valores em **variáveis de ambiente** no momento do deploy da aplicação, para tornar de mais difícil acesso.

Então apesar de o projeto ser uma prática, mantive estes valores nestas variáveis e não diretamente no código.

## Execução

Aplique no terminal:

    dotnet build
    dotnet run

Caso apareça uma mensagem de aviso/warning sobre não ter sido possível definir a porta https, faça:

    # A flag 'lp' significa 'launch profile'
    dotnet run -lp https

Agora, veja o link fornecido no terminal (localhost + porta) e abra-o no seu navegador. Exemplo:

    https://localhost:7141/swagger/index.html

Este link vai te levar para a página de **documentação do swagger**, então a partir dela você pode fazer requisições de teste.
