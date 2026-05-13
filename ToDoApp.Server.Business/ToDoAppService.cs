using ToDoApp.Server.Business.Contracts;
using ToDoApp.Server.Business.Dtos;
using ToDoApp.Server.Data.Repository.Contracts;

namespace ToDoApp.Server.Business
{
    public class ToDoAppService : IToDoAppService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoAppService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public async Task<ToDoItemDto> AddToDoItemAsync(ToDoItemDto item)
        {
            var returnedItem = await _toDoRepository.AddAsync(item.ToModel());
            return returnedItem.ToDto();
        }

        public async Task<List<ToDoItemDto>> GetAllToDoItemsAsync()
        {
            var returnedItems = await _toDoRepository.GetAllAsync();
            return returnedItems.Select(x => x.ToDto()).ToList();
        }

        public async Task<ToDoItemDto?> GetToDoItemByIdAsync(int id)
        {
            var returnedItem = await _toDoRepository.GetByIdAsync(id);
            return returnedItem?.ToDto();
        }

        public async Task<bool> DeleteToDoItemAsync(int id)
        {
            return await _toDoRepository.DeleteAsync(id);
        }
    }
}
