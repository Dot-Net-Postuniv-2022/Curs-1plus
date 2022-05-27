using TodoApi.Models;

public class TodoSubItem
{
    public long Id { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public int Priority { get; set; }
    public TodoItem Parent { get; set; }
}