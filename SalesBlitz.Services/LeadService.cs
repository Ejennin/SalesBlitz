using SalesBlitz.Data;
using SalesBlitz.Models.LeadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SalesLead.Service

{
    public class LeadService
    {
        private Guid leadId;

        public LeadService(Guid leadId)
        {
            this.leadId = leadId;
        }

        public bool CreateLead(SalesBlitz.Models.LeadModels.LeadCreate model)
        {
            var entity =
                new Lead()
                {

                    Content = model.Content,
                    Origin = model.Origin,
                    Status = model.Status,
                    BlitzID = model.BlitzID,

                    
                    CreatedUtc = model.CreatedUtc

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Leads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SalesBlitz.Models.LeadModels.LeadItem> GetLead()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        
                        .Leads
                        //.ToList()
                        // int LeadId = 0;
                        //.Where(e => e.LeadId == LeadId)
                        .Select(
                            e =>
                                new LeadItem
                                {
                                    LeadId = e.LeadId,
                                    Content = e.Content,
                                    Origin = e.Origin,
                                    Status = e.Status,
                                    //BlitzId = e.BlitzId,
                                    CreatedUtc = e.CreatedUtc

                                }
                        );

                return query.ToArray();
            }
        }

        public LeadDetail GetLeadById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Leads
                        .Single(e => e.LeadId == id);
                return
                    new LeadDetail
                    {
                        LeadId = entity.LeadId,
                        Content = entity.Content,
                        Origin = entity.Origin,
                        Status = entity.Status,
                        //BlitzID = entity.BlitzId
                        


                    };
            }
        }

        public bool UpdateLead(LeadEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.LeadId == model.LeadId);

                entity.Content = model.Content;
                entity.Status = (string)model.Status;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLead(int LeadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.LeadId == LeadId);

                ctx.Leads.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
