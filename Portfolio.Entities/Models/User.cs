using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public required string FullName { get; set; }

        [StringLength(250)]
        public string? About { get; set; }

        [StringLength(100)]
        public required string Education { get; set; }

        public required string ProfileImage { get; set; }

        // Kullanıcı Projeleri:
        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
