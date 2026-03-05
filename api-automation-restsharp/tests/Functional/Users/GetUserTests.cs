using System.Net;
using System.Text.Json;
using ApiAutomationRestSharp.Core.Base;
using ApiAutomationRestSharp.Routes;
using ApiAutomationRestSharp.Schemas;
using RestSharp;

namespace ApiAutomationRestSharp.Tests.Users
{
public class GetUserTests : BaseTest
    {
        [Fact]
        public void Deve_retornar_usuarios()
        {

            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get); // O header x-api-key já é adicionado no GetRestClient do BaseTest
            
            // Act
            var response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Assert
            Assert.True(response.IsSuccessful, $"A API não está online. Status: {response.StatusCode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // Verifica se o status code é 200 OK
            Assert.NotNull(response.Content); // Verifica se o conteúdo da resposta não é nulo
            Assert.Contains("application/json", response.ContentType); // Verifica se o tipo de conteúdo é JSON
            
            var usersResponse = JsonSerializer.Deserialize<UsersResponse>(response.Content);
            Assert.NotNull(usersResponse); // Verifica se a desserialização foi bem-sucedida

            Assert.True(usersResponse.Page > 0);
            Assert.True(usersResponse.Per_Page > 0);
            Assert.True(usersResponse.Total >= usersResponse.Data.Count);

            Assert.NotNull(usersResponse.Data); // Verifica se a propriedade Data retorna usuários
            Assert.NotEmpty(usersResponse.Data); // Verifica se a lista de usuários não está vazia

            Assert.All(usersResponse.Data, user => // Validações para cada usuário. Equivalente a um loop foreach
            {
                Assert.True(user.Id > 0, "O ID do usuário deve ser maior que zero");
                Assert.False(string.IsNullOrEmpty(user.Email), "O email do usuário não deve ser nulo ou vazio");
                Assert.False(string.IsNullOrEmpty(user.FirstName), "O primeiro nome do usuário não deve ser nulo ou vazio");
                Assert.False(string.IsNullOrEmpty(user.LastName), "O sobrenome do usuário não deve ser nulo ou vazio");
                Assert.False(string.IsNullOrEmpty(user.Avatar), "O avatar do usuário não deve ser nulo ou vazio");
            });

        }

        // [Fact]
        // public async Task GetUsers_ShouldReturnEmptyList_WhenPageDoesNotExist()
        // {
        //     // Arrange
        //     var client = GetRestClient();
        //     var request = new RestRequest(Endpoints.Users, Method.Get); // O header x-api-key já é adicionado no GetRestClient do BaseTest
        //     request.AddQueryParameter("page", "999");
        //     // Act
        //     var response = client.Execute(request);

        //     // Assert
        //     var usersResponse = JsonSerializer.Deserialize<UsersResponse>(response.Content);

        //     Assert.NotNull(response.Data);
        //     Assert.Empty(response.Data.Data);
        // }
    }
}