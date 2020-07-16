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
        public int RepsId { get; set; }
        public string RepName { get; set; }
        //public string Position { get; set; }


        [ForeignKey(nameof(Rep))]
        public int RepId { get; set; }
        public virtual Rep Rep { get; set; }

        [ForeignKey(nameof(Blitz))]
        public int BlitzId { get; set; }

        public virtual Blitz Blitz { get; set; }
        public string Position { get; set; }
    }
}

