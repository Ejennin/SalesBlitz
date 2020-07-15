using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Data
{
    public class RepsAtBlitz
    {
        
        [Key]
        public int RepId { get; set; }
        public int BlitzId { get; set; }
        public bool HomeArea { get; set; }

        [ForeignKey("Rep")]
        public String RepName { get; set; }
        public string Position { get; set; }

        
    }
}

