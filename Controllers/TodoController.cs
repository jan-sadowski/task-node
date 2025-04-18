using Microsoft.AspNetCore.Mvc;
using TaskNode.Dtos;
using TaskNode.Models;
using TaskNode.Services;

namespace TaskNode.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
        var items = await _todoService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        var item = await _todoService.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] TodoItemDto? item)
    {
        await _todoService.AddAsync(item);
        return CreatedAtAction(nameof(GetTodoById), new { id = item.Id }, item); // Zmienione na GetTodoById
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoItemDto? item)
    {
        await _todoService.UpdateAsync(id, item);
        return NoContent();
    } 
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        await _todoService.DeleteAsync(id);
        return NoContent();
    }
}