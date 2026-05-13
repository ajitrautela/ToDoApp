using Microsoft.EntityFrameworkCore;
using ToDoApp.Server.Models.Domain;

namespace ToDoApp.Server.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}