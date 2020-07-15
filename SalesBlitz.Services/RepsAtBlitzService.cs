using SalesBlitz.Data;
using SalesBlitz.Models.RepsAtBlitzModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SalesBlitz.Services
{
    public class RepsAtBlitzService
    {
        private readonly int BlitzId;

        public bool CreateRepAtBlitz(RepAtBlitzEdit model)
        {
            var entity =
                new RepAtBlitzCreate()
                {

                    RepId = model.RepId,
                    BlitzId = model.BlitzId,
                    HomeArea = model.HomeArea,
                    RepName = model.RepName,
                    Position = model.Position,
                    


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RepAtBlitz.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateRepAtBlitz()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepAtBlitzItem> GetBlitz()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        // May need to change out BlitzID to RepId or Lead Id
                        .Blitzes
                        .ToList()
                        // int BlitzId = 0;
                        .Where(e => e.BlitzId == BlitzId)
                        .Select(
                            e =>
                                new RepAtBlitzItem
                                {
                                    
                                    BlitzId = e.BlitzId,
                                    

                                }
                        );

                return query.ToArray();
            }
        }

        public RepAtBlitzDetail GetRepAtBlitzById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Blitzes
                        .Single(e => e.BlitzId == id);
                return
                    new RepAtBlitzDetail
                    {
                        BlitzId = entity.BlitzId,
                        
                        


                    };
            }
        }

        public bool UpdateRepAtBlitz(RepAtBlitzEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepAtBlitz
                        .Single(e => e.RepId == model.RepId);

                entity.RepId = model.RepId;
                entity.BlitzId = model.BlitzId;
                entity.HomeArea = model.HomeArea;
                entity.RepName = (string)model.RepName;
                entity.Position = model.Position;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRepAtBlitz(int RepId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepAtBlitz
                        .Single(e => e.RepId == RepId);

                ctx.Blitzes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
    
