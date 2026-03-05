// // Centraliza chamadas HTTP | Evita repetição | Mantém testes limpos
// Encapsula o RestSharp.
using RestSharp;

namespace ApiAutomationRestSharp.Clients;

public class ReqResClient{
    protected string ApiKey { get; } = "reqres_94b85a574fa84547ba21c6a2082617ee";
    protected Uri BaseAddress { get; } = new Uri("https://reqres.in/api/"); //Uri é uma classe do .NET que representa um endereço URI (Uniform Resource Identifier)

    protected RestClient GetRestClient() //RestClient é a classe principal do RestSharp para fazer requisições HTTP
    {
        var options = new RestClientOptions(BaseAddress) // Configurações adicionais do cliente
        {
            ThrowOnAnyError = true, // Lança exceção para qualquer status de erro
            Timeout = TimeSpan.FromMilliseconds(10000) // Define um timeout de 10 segundos para as requisições
        };
        
        var client = new RestClient(options); // Cria o cliente RestSharp com as opções configuradas
        client.AddDefaultHeader("x-api-key", ApiKey); // Adiciona o header de autenticação com a chave da API
        return client;
    }
}