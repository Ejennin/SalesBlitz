using SalesBlitz.Data;
using SalesBlitz.Models.RepsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SalesReps.Services
{
    public class RepsService
    
    {
        public bool CreateReps(RepCreate model)
        {
            var entity =
                new Rep()
                {

                    RepId = model.RepId,
                    RepName = model.RepName,
                    Position = model.Position,
                    CreatedUtc = model.CreatedUtc

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reps.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RepList> GetRep()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        // May need to change out RepsID to RepId or Lead Id
                        .Reps
                        //.ToList();
                        // int RepsId = 0;
                        //.Where(e => e.RepsId == RepsId)
                        .Select(
                            e =>
                                new RepList
                                {
                                    RepId = e.RepId,
                                    RepName = e.RepName,
                                    Position = e.Position,
                                    

                                }
                        );

                return query.ToArray();
            }
        }

        public RepDetail GetRepById(int RepId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Reps
                        .Single(e => e.RepId == RepId);
                return
                    new RepDetail
                    {
                        RepId = entity.RepId,
                        RepName = entity.RepName,
                        Position = entity.Position,
                        //Location = entity.Location


                    };
            }
        }

        public bool UpdateReps(RepEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reps
                        .Single(e => e.RepId == model.RepId);

                entity.RepId = model.RepId;
                entity.RepName = (string)model.RepName;
                entity.Position = model.Position;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRep(int RepId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reps
                        .Single(e => e.RepId == RepId);

                ctx.Reps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }


}

