using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Data
{
    public class Lead
    {
        [Key]
        public int LeadId { get; set; }
        [Required]
        public string Content { get; set; }

        public string Origin { get; set; }

        public string Status { get; set; }

        public int BlitzID { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public string Url { get; set; }

    }
}

