using SalesBlitz.Data;
using SalesBlitz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBlitz.Service
{
    public class BlitzService
    {
        private readonly Guid _userId;
        public BlitzService (Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBlitz(BlitzCreate model)
        {
            var entity =
                new Blitz()
                {
                    
                    Name = model.Name,
                    Location = model.Location,
                    Date = model.Date,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Blitzes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BlitzItem> GetBlitzes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                int BlitzId = 0;
                var query =
                    ctx
                        .Blitzes
                        .Where(e => e.BlitzId == BlitzId)
                        .Select(
                            e =>
                                new BlitzItem
                                {
                                    BlitzId = e.BlitzId,
                                    Name = e.Name,
                                    Location = e.Location,
                                    Date = e.Date

                                }
                        );

                return query.ToArray();
            }
        }
    }
}
