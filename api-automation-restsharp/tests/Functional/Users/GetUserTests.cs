using System.Net;
using System.Text.Json;
using Core.Base;
using Routes;
using Schemas;
using RestSharp;
using FluentAssertions;

namespace Tests.Functional.Users
{
    public class GetUserTests : BaseTest
    {
        [Fact]
        public void GetUsers_Deve_Retornar_Dados_Da_Paginacao()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get);
            
            // Act
            var response = client.Execute(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var usersResponse = JsonSerializer.Deserialize<UsersResponse>(response.Content ?? string.Empty);

            usersResponse.Should().NotBeNull();
            usersResponse.Page.Should().BeGreaterThan(0);
            usersResponse.Per_Page.Should().BeGreaterThan(0);
            usersResponse.Total.Should().BeGreaterThanOrEqualTo(usersResponse.Data.Count);

            usersResponse.Data.Should().NotBeNull();
            usersResponse.Data.Should().NotBeEmpty();
        }

        [Fact]
        public void GetUsers_Deve_Retornar_Usuarios()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get); 

            // Act
            var response = client.Execute(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK); 
            
            var usersResponse = JsonSerializer.Deserialize<UsersResponse>(response.Content ?? string.Empty); 
            usersResponse.Should().NotBeNull(); 
            usersResponse.Data.Should().NotBeNull(); 
            usersResponse.Data.Should().NotBeEmpty(); 

            foreach(var user in usersResponse.Data)
            {
                user.Id.Should().BeGreaterThan(0);
                user.Email.Should().NotBeNullOrWhiteSpace();
                user.FirstName.Should().NotBeNullOrWhiteSpace();
                user.LastName.Should().NotBeNullOrWhiteSpace();
                user.Avatar.Should().NotBeNullOrWhiteSpace();
            };
        }

        [Fact]
        public async Task GetUsers_Deve_Retornar_Lista_Vazia_Quando_Pagina_Nao_Existir()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get);
            request.AddQueryParameter("page", "999");

            // Act
            var response = client.Execute(request);

            // Assert
            var usersResponse = JsonSerializer.Deserialize<UsersResponse>(response.Content ?? string.Empty); 

            usersResponse.Should().NotBeNull();
            usersResponse.Data.Should().NotBeNull();
            usersResponse.Data.Should().BeEmpty(); 
        }
    }
}