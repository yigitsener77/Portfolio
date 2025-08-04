namespace Portfolio.Models
{
    public class MessageViewModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}
