<h1>Calcular a rota mais econômica entre dois pontos</h1>

<div>
  <p>Este projeto é um teste para o Banco Master, que tem como objetivo criar uma API de rotas (ponto A -> ponto B) com um valor associado. O desafio é calcular a rota mais econômica, mesmo que isso aumente o número de pontos das rotas, e retornar a melhor rota.</p>
  <p><strong>Tecnologias usadas</strong></p>
  <ul>
    <li>.NET Core 3.1</li>
    <li>DDD (Domain-Driven Design)</li>
    <li>ORM (EF Core 3.1)</li>
    <li>Fluent Validation</li>
    <li>Injeção de Dependência</li>
    <li>Automapper</li>
    <li>Code-First Migration</li>
  </ul>
  <p><strong>Como executar o projeto</strong></p>
  <ol>
    <li>Clone o projeto</li>
    <li>Abra o projeto no Visual Studio e espere que todas as dependências sejam baixadas</li>
    <li>Altere a string de conexão no arquivo "appsettings.json" na camada de Application</li>
    <li>Rode os comandos de migrations (pode ser feito no terminal do Visual Studio ou em outro terminal de sua preferência)</li>
<li>Rode os comandos de migrations (pode ser feito no terminal do Visual Studio ou em outro terminal de sua preferência)
    <ul>
      <li>cd Data</li>
      <li>dotnet ef migrations enable</li>
      <li>dotnet ef migrations add InitialCreate</li>
      <li>dotnet ef database update InitialCreate</li>
    </ul>
    <li>Depois de rodar os comandos de migrações, o banco de dados será criado e o projeto pode ser executado pelo IIS ou pelo ambiente de depuração do Visual Studio</li>
    <li>A interface Swagger mostrará os endpoints CRUD de rotas e um endpoint para calcular a rota econômica, basta informar dois pontos de origem e destino</li>
  </ol>
<h3>Estrutura da solução</h3>
<ul>
  <li><b>Camada de testes:</b> contém um teste simples que verifica se o retorno do mock é o mesmo da implementação do serviço de cálculo de rota.</li>
  <li><b>Automapper:</b> permite mapear objetos que vem da web para o banco e vice-versa.</li>
  <li><b>Injeção de dependência:</b> as dependências são configuradas no container na classe Startup.</li>
  <li><b>Validações:</b> validações simples para inserir e atualizar dados na camada de serviço usando Fluent Validation. Há também uma validação sem biblioteca para verificar se a rota já existe.</li>
  <li><b>Enum:</b> foi criado um enum na camada de domínio que contém algumas rotas, além das que já existem, e só permite novos inserts se estiverem neste enum (validado pelo Fluent Validation).</li>
  <li><b>Camada de dados:</b> na camada de dados há uma pasta com as queries, incluindo a query que é passada pelo Entity para trazer as rotas rankeadas pelo melhor valor.</li>
</ul>
