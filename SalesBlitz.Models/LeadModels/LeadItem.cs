using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models.LeadModels
{
    public class LeadItem
    {
        public int LeadId { get; set; }
        
        public string Content { get; set; }

        public string Origin { get; set; }

        public string Status { get; set; }

        public int BlitzId { get; set; }

        [DisplayName("Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
