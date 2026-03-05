using RestSharp;
using ApiAutomationRestSharp.Routes;
using System.Net;
using ApiAutomationRestSharp.Core.Base;
using ApiAutomationRestSharp.Clients;

namespace ApiAutomationRestSharp.Tests.Smoke
{
    public class GetUserByIdTests : BaseTest
    {
        [Fact]
        public void GetUser_Deve_Retornar_Sucesso()
        {
            
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.UsersById.Replace("{id}", "2"), Method.Get);
            // O header x-api-key já é adicionado no GetRestClient do BaseTest
            var response = client.Execute(request);

            Assert.True(response.IsSuccessful, $"A API não está online. Status: {response.StatusCode}");
            //IsSuccessful é uma propriedade do RestResponse que indica se a resposta foi bem-sucedida (status code 200-299)
        }

    }
}
