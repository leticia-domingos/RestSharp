using RestSharp;
using ApiAutomationRestSharp.Routes;
using ApiAutomationRestSharp.Core.Base;


namespace ApiAutomationRestSharp.Tests.Smoke
{
    public class UsersSmokeTests : BaseTest
    {
        [Fact]
        public void GetUser_Should_Return_Success()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get); // O header x-api-key já é adicionado no GetRestClient do BaseTest


            // Act
            var response = client.Execute(request);

            // Assert
            Assert.True(response.IsSuccessful, $"A API não está online. Status: {response.StatusCode}"); //IsSuccessful é uma propriedade do RestResponse que indica se a resposta foi bem-sucedida (status code 200-299)
        }

    }
}
