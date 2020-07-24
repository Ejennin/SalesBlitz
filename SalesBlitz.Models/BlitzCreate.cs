using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models
{
    public class BlitzCreate
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
