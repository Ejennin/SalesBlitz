using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models.RepsAtBlitzModels
{
    public class RepAtBlitzCreate
    {
        public int RepsId { get; set; }
        public int BlitzId { get; set; }
        public bool HomeArea { get; set; }

        public string BlitzName { get; set; }

        public string RepName { get; set; }
        public string Position { get; set; }
    }
}

