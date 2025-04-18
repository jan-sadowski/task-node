using Microsoft.EntityFrameworkCore;
using TaskNode.Data;
using TaskNode.Dtos;
using TaskNode.Models;

namespace TaskNode.Services;

public class TodoService : ITodoService
{
    private readonly TodoContext _context;

    public TodoService(TodoContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItemDto>> GetAllAsync()
    {
        return await _context.TodoItems
            .Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                IsComplete = item.IsComplete
            })
            .ToListAsync();
    }

    public async Task<TodoItemDto?> GetByIdAsync(int id)
    {
        var item = await _context.TodoItems
            .Where(t => t.Id == id)
            .Select(i => new TodoItemDto
            {
                Id = i.Id,
                Title = i.Title,
                IsComplete = i.IsComplete
            })
            .FirstOrDefaultAsync();

        return item;
    }

    public async Task AddAsync(TodoItemDto? itemDto)
    {
        if (itemDto != null)
        {
            var item = new TodoItem
            {
                Title = itemDto.Title,
                IsComplete = itemDto.IsComplete
            };

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task UpdateAsync(int id, TodoItemDto? itemDto)
    {
        var existing = await _context.TodoItems.FindAsync(id);
    
        if (existing == null) return;

        if (itemDto != null)
        {
            existing.Title = itemDto.Title;
            existing.IsComplete = itemDto.IsComplete;
        }

        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item != null)
        {
            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}