namespace Portfolio.Models
{
    public class ProjectViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? Link { get; set; }
        public string? ImageUrl { get; set; }
    }
}
