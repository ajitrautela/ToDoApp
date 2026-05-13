using ToDoApp.Server.Models.Domain;

namespace ToDoApp.Server.Data.Repository.Contracts
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task<ToDoItem> AddAsync(ToDoItem item);
        Task<bool> DeleteAsync(int id);
    }
}
