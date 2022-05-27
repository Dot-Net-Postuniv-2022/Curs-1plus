namespace TodoApi.DTOs
{
    public class TodoSubItemDTO
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }
    }
}