namespace TodoApi.DTOs
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }

        public ICollection<TodoSubItemDTO>? TodoSubItems { get; set; }
    }
}