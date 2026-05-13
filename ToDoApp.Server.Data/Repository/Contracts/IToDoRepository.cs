using ToDoApp.Server.Models.Domain;

namespace ToDoApp.Server.Data.Repository.Contracts
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(Guid id);
        Task<ToDoItem> AddAsync(ToDoItem item);
        Task<bool> DeleteAsync(Guid id);
    }
}
