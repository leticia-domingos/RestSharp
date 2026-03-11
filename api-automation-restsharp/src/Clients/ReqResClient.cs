using RestSharp;

namespace Clients;

public class ReqResClient{
    protected string ApiKey { get; } = "reqres_94b85a574fa84547ba21c6a2082617ee";
    protected Uri BaseAddress { get; } = new Uri("https://reqres.in/api/");

    protected RestClient GetRestClient()
    {
        var options = new RestClientOptions(BaseAddress)
        {
            ThrowOnAnyError = true,
            Timeout = TimeSpan.FromMilliseconds(10000)
        };
        
        var client = new RestClient(options);
        client.AddDefaultHeader("x-api-key", ApiKey);
        return client;
    }
}