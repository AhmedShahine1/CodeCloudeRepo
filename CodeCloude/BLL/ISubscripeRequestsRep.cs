using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface ISubscripeRequestsRep
    {
        
        IEnumerable<SubscripeRequests> Get();
        SubscripeRequests GetById(int id);
        void Creat(SubscripeRequests obj);
        void Edite(SubscripeRequests obj);
        void Delete(SubscripeRequests obj);
    }
    public class SubscripeRequestsRep : ISubscripeRequestsRep
    {
        private readonly CodeCloude_DbContext db;
        public SubscripeRequestsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<SubscripeRequests> Get()
        {
            var All = db.SubscripeRequests.Select(a => a).Include("ApplicationUser").Include("Subscriptions");
            return All;
        }
        public SubscripeRequests GetById(int id)
        {
            var data = db.SubscripeRequests.Where(x => x.Id == id).Include("ApplicationUser").Include("Subscriptions").FirstOrDefault();
            return data;
        }

        public void Creat(SubscripeRequests obj)
        {
            db.SubscripeRequests.Add(obj);
            db.SaveChanges();

        }

        public void Delete(SubscripeRequests obj)
        {
            var olddata = db.SubscripeRequests.Find(obj.Id);
            db.SubscripeRequests.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(SubscripeRequests obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
