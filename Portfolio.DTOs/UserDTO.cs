using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public string? About { get; set; }
        public required string Education { get; set; }
        public required string ProfileImage { get; set; }
        // Gerekirse sadece okunacak tipte projeler eklemek için.
        public List<ProjectDTO> Projects { get; set; } = new List<ProjectDTO>();
    }
}
