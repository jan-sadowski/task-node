using TaskNode.Dtos;
using TaskNode.Models;

namespace TaskNode.Services;

public interface ITodoService
{
    Task<List<TodoItemDto>> GetAllAsync();
    Task<TodoItemDto?> GetByIdAsync(int id);
    Task AddAsync(TodoItemDto? item);
    Task UpdateAsync(int id, TodoItemDto? item);
    Task DeleteAsync(int id);
}