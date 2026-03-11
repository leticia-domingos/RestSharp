# API Automation RestSharp

Este projeto é um Framework de automação de testes de API desenvolvido em C# para validação de endpoints REST.  
O projeto utiliza RestSharp para requisições HTTP, xUnit como framework de testes e FluentAssertions para validações mais legíveis.


## Objetivo

O objetivo deste projeto é demonstrar a criação de um framework estruturado para automação de testes de API, cobrindo diferentes tipos de validações e boas práticas de organização de testes.


## Tecnologias Utilizadas

- **.NET 10.0**: Framework de desenvolvimento.
- **RestSharp**: Biblioteca para consumir APIs REST.
- **xUnit**: Framework de testes unitários.
- **FluentAssertions**: Biblioteca para asserções fluentes em testes.
- **JsonSchema.Net**: Para validação de esquemas JSON.
- **Microsoft.NET.Test.Sdk**: SDK para testes .NET.


## Status do projeto
🚧 **Em desenvolvimento**

Os testes estão sendo implementados e refinados gradualmente conforme a evolução do projeto.


## Roadmap

- [x] Estrutura inicial do framework
- [x] Implementação de smoke tests
- [ ] Implementação dos testes funcionais (Em Andamento)
- [ ] Implementação de testes de contrato
- [ ] Implementação de testes negativos
- [ ] Implementação de testes de performance
- [ ] Implementação de testes de segurança


## Tipos de testes

Este projeto contempla diferentes estratégias de teste para APIs:

- **Smoke Tests**  
  Verificam rapidamente se a API está online e respondendo corretamente.

- **Testes Funcionais**  
  Validam o comportamento esperado dos endpoints e a integridade dos dados retornados.

- **Testes de Contrato**  
  Garantem que a estrutura da resposta da API permanece consistente.

- **Testes Negativos**  
  Verificam o comportamento da API diante de entradas inválidas.

- **Testes de Performance**  
  Avaliam o tempo de resposta dos endpoints.

- **Testes de Segurança**  
  Validam cenários relacionados a autenticação, autorização e possíveis vulnerabilidades.


## Estrutura do Projeto

- **src/**: Contém o código fonte do framework.
  - **Clients/**: Clientes para interagir com APIs (ex: ReqResClient.cs).
  - **Config/**: Configurações de teste (ex: TestSettings.cs).
  - **Core/**: Núcleo do framework.
    - **Base/**: Classes base (ex: BaseTest.cs).
    - **Routes/**: Definições de endpoints (ex: UsersEndpoints.cs).
  - **Schemas/**: Esquemas JSON para validação (ex: user.schema.json, Users.cs, UsersResponse.cs).

- **tests/**: Contém os testes automatizados.
  - **Contract/**: Testes de contrato (Em breve).
  - **Functional/**: Testes funcionais (Em Desenvolvimento).
  - **Negative/**: Testes negativos (Em breve).
  - **Performance/**: Testes de performance (Em breve).
  - **Security/**: Testes de segurança (Em breve).
  - **Smoke/**: Testes smoke (Concluído).


## Pré-requisitos

- .NET SDK 10.0 ou superior instalado.
- Um editor de código como Visual Studio Code ou Visual Studio.

## Instalação

1. Clone o repositório:
   ```
   git clone <url-do-repositorio>
   cd api-automation-restsharp
   ```

2. Restaure as dependências:
   ```
   dotnet restore
   ```

## Como Executar os Testes

Para executar todos os testes:
```
dotnet test
```

Para executar testes específicos (ex: apenas smoke tests):
```
dotnet test --filter "Category=Smoke"
```

Para executar com cobertura de código (se configurado):
```
dotnet test --collect:"XPlat Code Coverage"
```

## Configuração

- Endpoints são definidos em `src/Core/Routes/UsersEndpoints.cs`.
- A classe base `BaseTest.cs` configura o cliente RestSharp com headers necessários.
