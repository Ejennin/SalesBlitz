using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models.LeadModels
{
    public class LeadDetail
    {
        public int LeadId { get; set; }
        [Required]
        public string Content { get; set; }

        public string Origin { get; set; }

        public string Status { get; set; }

        public int BlitzID { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
