﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Data
{
    public class Blitz
    {
        public readonly Guid UserId;

        [Key]
        public int BlitzId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public string Url { get; set; }


        public ICollection<RepsAtBlitz> RepsAtBlitzes { get; set; }

        public ICollection<Lead> Leads { get; set; } 





    }
}
