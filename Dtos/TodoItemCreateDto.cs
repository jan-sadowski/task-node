namespace TaskNode.Dtos;

public class TodoItemCreateDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}