using RestSharp;
using Routes;
using Core.Base;
using System.Net;
using FluentAssertions;


namespace Tests.Smoke
{
    public class UsersSmokeTests : BaseTest
    {
        [Fact]
        public void GetUser_Deve_Retornar_Sucesso()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get); 


            // Act
            var response = client.Execute(request);

            // Assert
            response.IsSuccessful.Should().BeTrue($"A API não está online. Status: {response.StatusCode}");
            response.StatusCode.Should().Be(HttpStatusCode.OK); 
            response.Content.Should().NotBeNull();
            response.ContentType.Should().Contain("application/json");
        }

    }
}
