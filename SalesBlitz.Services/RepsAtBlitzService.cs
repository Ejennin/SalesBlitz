using SalesBlitz.Data;
using SalesBlitz.Models.RepsAtBlitzModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Linq;

namespace SalesBlitz.Services
{
    public class RepsAtBlitzService
    {




        public bool CreateRepAtBlitz(RepAtBlitzCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                int repId = ctx.Reps.FirstOrDefault(e => e.RepName == model.RepName).RepId;

                int blitzId = ctx.Blitzes.FirstOrDefault(e => e.Name == model.BlitzName).BlitzId;
                var entity =
                    new RepsAtBlitz()
                    {

                        RepsId = model.RepsId,
                    //    BlitzId = model.BlitzId,
                    //HomeArea = model.HomeArea,
                        RepName = model.RepName,
                    //Position = model.Position,
                     //   BlitzName = model.BlitzName,
                        RepId = repId,
                        BlitzId = blitzId


                    };


                ctx.RepsAtBlitzes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateRepAtBlitz()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepAtBlitzItem> GetBlitz(int BlitzId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        // May need to change out BlitzID to RepId or Lead Id
                        .Blitzes
                        //.ToList()
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
                        .RepsAtBlitzes
                        .Single(e => e.RepId == model.RepId);

                entity.RepId = model.RepId;
                entity.BlitzId = model.BlitzId;
                //entity.HomeArea = model.HomeArea;
                entity.RepName = (string)model.RepName;
                //entity.Position = model.Position;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRepAtBlitz(int RepId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepsAtBlitzes
                        .Single(e => e.RepId == RepId);

                ctx.RepsAtBlitzes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

