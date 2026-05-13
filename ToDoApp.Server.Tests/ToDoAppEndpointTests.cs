using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;

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
            var create = new CreateTodoItemRequest("Test item");
            var postResponse = await _client.PostAsJsonAsync("/api/todos", create);
            postResponse.EnsureSuccessStatusCode();

            var list = await _client.GetFromJsonAsync<List<TodoItemDto>>("/api/todos");
            Assert.NotNull(list);
            Assert.Contains(list, x => x.Title == "Test item");
        }

        [Fact]
        public async Task Delete_Removes_Item()
        {
            var create = new CreateTodoItemRequest("To delete");
            var postResponse = await _client.PostAsJsonAsync("/api/todos", create);
            var created = await postResponse.Content.ReadFromJsonAsync<TodoItemDto>();

            var deleteResponse = await _client.DeleteAsync($"/api/todos/{created!.Id}");
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}
