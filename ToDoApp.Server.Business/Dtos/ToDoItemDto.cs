using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ToDoApp.Server.Models.Domain;

namespace ToDoApp.Server.Business.Dtos
{
    public class ToDoItemDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string ItemName { get; set; }
        public required bool IsCompleted { get; set; } = false;
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
                IsCompleted = item.IsCompleted
            };
        }
        public static ToDoItem ToModel(this ToDoItemDto item)
        {
            return new ToDoItem
            {
                Id = item.Id,
                ItemName = item.ItemName,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
