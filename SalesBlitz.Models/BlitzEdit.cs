using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models
{
    public class BlitzEdit
    {
        public int BlitzId { get; set; }

        public string Name { get; set; }
        public object Location { get; set; }
        public DateTime Date { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
