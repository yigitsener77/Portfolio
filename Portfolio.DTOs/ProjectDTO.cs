using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        public List<ProjectDTO> Projects { get; set; } = new List<ProjectDTO>();
    }
}
