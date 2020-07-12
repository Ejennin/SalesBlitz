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
        public readonly Guid _userId;
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
                    // May need to change out BlitzID to RepId or Lead Id
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

        public BlitzDetail GetBlitzById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Blitzes
                        .Single(e => e.BlitzId == id && e.UserId == _userId);
                return
                    new BlitzDetail
                    {
                        BlitzId = entity.BlitzId,
                        Name = entity.Name,
                        Location = entity.Location,
                        Date = entity.Date
                        
                    };
            }
        }

        public bool UpdateBlitz(BlitzEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Blitzes
                        .Single(e => e.BlitzId == model.BlitzId && e.UserId == _userId);

                entity.Name = model.Name;
                entity.Location = (string)model.Location;
                entity.Date = model.Date;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBlitz(int BlitzId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Blitzes
                        .Single(e => e.BlitzId == BlitzId && e.UserId == _userId);

                ctx.Blitzes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
