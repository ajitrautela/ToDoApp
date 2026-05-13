using ToDoApp.Server.Models.Domain;

namespace ToDoApp.Server.Business.Dtos
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public required string ItemName { get; set; }
    }

    // Mapping extension methods to convert between ToDoItem and ToDoItemDto
    public static class ToDoItemDtoExtensions
    {
        public static ToDoItemDto ToDto(this ToDoItem item)
        {
            return new ToDoItemDto
            {
                Id = item.Id,
                ItemName = item.ItemName,
            };
        }
        public static ToDoItem ToModel(this ToDoItemDto item)
        {
            return new ToDoItem
            {
                Id = item.Id,
                ItemName = item.ItemName,
            };
        }
    }
}
