using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Models.RepsModels
{
    public class RepCreate
    {
        public int RepId { get; set; }
        public String RepName { get; set; }
        public string Position { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
