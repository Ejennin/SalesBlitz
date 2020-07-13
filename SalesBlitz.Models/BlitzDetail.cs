using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models
{
    public class BlitzDetail
    {
        public int BlitzId { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
