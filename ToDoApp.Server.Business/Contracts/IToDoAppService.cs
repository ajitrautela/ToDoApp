using ToDoApp.Server.Business.Dtos;

namespace ToDoApp.Server.Business.Contracts
{
    public interface IToDoAppService
    {
        Task<List<ToDoItemDto>> GetAllToDoItemsAsync();
        Task<ToDoItemDto?> GetToDoItemByIdAsync(Guid id);
        Task<ToDoItemDto> AddToDoItemAsync(ToDoItemDto item);
        Task<bool> DeleteToDoItemAsync(Guid id);
    }
}
