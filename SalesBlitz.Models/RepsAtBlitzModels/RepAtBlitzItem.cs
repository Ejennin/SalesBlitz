using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models.RepsAtBlitzModels
{
    public class RepAtBlitzItem
    {
        public int RepId { get; set; }
        public int BlitzId { get; set; }
        public bool HomeArea { get; set; }

        public String RepName { get; set; }
        public string Position { get; set; }
    }
}
