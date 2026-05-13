using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Server.Data.Repository.Contracts;
using ToDoApp.Server.Models.Domain;

namespace ToDoApp.Server.Data.Repository
{
    public class ToDoRepository : IToDoRepositoy
    {
        private readonly ToDoDbContext _dbContext;
        public ToDoRepository(ToDoDbContext toDoDbContext)
        {
            _dbContext = toDoDbContext;
        }
        public async Task<ToDoItem> AddAsync(ToDoItem item)
        {
            var newItem = _dbContext.ToDoItems.Attach(item);
            await _dbContext.SaveChangesAsync();

            return newItem.Entity;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _dbContext.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem?> GetByIdAsync(Guid id)
        {
            var item = await _dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return false;

            _dbContext.ToDoItems.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
