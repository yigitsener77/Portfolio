using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DTOs
{
    public class ContactMessageDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
