namespace TaskNode.Dtos;

public class TodoItemUpdateDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}