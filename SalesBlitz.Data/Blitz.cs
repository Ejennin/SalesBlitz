using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Data
{
    public class Blitz
    {
        [Key]
        public int BlitzId { get; set; }
        public String Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
    }
}
