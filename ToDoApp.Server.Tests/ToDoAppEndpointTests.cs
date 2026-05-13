using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using ToDoApp.Server.Business.Dtos;

namespace ToDoApp.Server.Tests
{
    public class ToDoAppEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ToDoAppEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Then_Get_Returns_Item()
        {
            var create = new PostRequestDto("Test add item");
            var postResponse = await _client.PostAsJsonAsync("/api/v1/todoitems", create);
            postResponse.EnsureSuccessStatusCode();

            var list = await _client.GetFromJsonAsync<List<ToDoItemDto>>("/api/v1/todoitems");
            Assert.NotNull(list);
            Assert.Contains(list, x => x.ItemName == "Test add item");
        }

        [Fact]
        public async Task Delete_Removes_Item()
        {
            var create = new PostRequestDto("Delete item");
            var postResponse = await _client.PostAsJsonAsync("/api/v1/todoitems", create);
            var created = await postResponse.Content.ReadFromJsonAsync<ToDoItemDto>();

            var deleteResponse = await _client.DeleteAsync($"/api/v1/todoitems/{created!.Id}");
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}
