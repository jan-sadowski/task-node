using Microsoft.EntityFrameworkCore;
using TaskNode.Data;
using TaskNode.Dtos;
using TaskNode.Models;
using AutoMapper;

namespace TaskNode.Services;

public class TodoService : ITodoService
{
    private readonly IMapper _mapper;
    private readonly TodoContext _context;

    public TodoService(IMapper mapper, TodoContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<TodoItemDto>> GetAllAsync()
    {
        var items = await _context.TodoItems.ToListAsync();
        return _mapper.Map<List<TodoItemDto>>(items);
    }

    public async Task<TodoItemDto?> GetByIdAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        return _mapper.Map<TodoItemDto>(item);
    }

    public async Task<TodoItemDto?> AddAsync(TodoItemCreateDto? itemDto)
    {
        var item = _mapper.Map<TodoItem>(itemDto);
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();
        return _mapper.Map<TodoItemDto>(item);
    }
    
    public async Task UpdateAsync(int id, TodoItemUpdateDto? itemDto)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item != null)
        {
            _mapper.Map(itemDto, item);
            await _context.SaveChangesAsync();
        }
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