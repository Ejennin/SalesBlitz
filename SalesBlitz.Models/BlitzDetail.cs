using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models
{
    public class BlitzDetail
    {
        public int BlitzId { get; set; }

        public string Name { get; set; }
        public object Location { get; set; }
        public DateTime Date { get; set; }
    }
}
