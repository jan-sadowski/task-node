using TaskNode.Dtos;
using TaskNode.Models;

namespace TaskNode.Services;

public interface ITodoService
{
    Task<List<TodoItemDto>> GetAllAsync();
    Task<TodoItemDto?> GetByIdAsync(int id);
    Task<TodoItemDto?> AddAsync(TodoItemCreateDto dto);
    Task UpdateAsync(int id, TodoItemUpdateDto dto);
    Task DeleteAsync(int id);
}