using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Data
{
    public class Rep
    {
        [Key]
        public int RepId { get; set; }
        [Required]
        public string RepName { get; set; }
        public string Position { get; set; }

        public bool HomeArea { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public ICollection<RepsAtBlitz> RepsAtBlitzes { get; set; }
    }
}
