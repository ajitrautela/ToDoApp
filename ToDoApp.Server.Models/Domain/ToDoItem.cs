using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Server.Models.Domain
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string ItemName { get; set; }
        public required bool IsCompleted { get; set; } = false;
    }
}
