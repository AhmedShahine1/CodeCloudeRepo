using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface ISubscriptionsRep
    {
        IEnumerable<Subscriptions> Get();
        Subscriptions GetById(int id);
        void Creat(Subscriptions obj);
        void Edite(Subscriptions obj);
        void Delete(Subscriptions obj);
    }
    public class SubscriptionsRep : ISubscriptionsRep
    {
        private readonly CodeCloude_DbContext db;
        public SubscriptionsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Subscriptions> Get()
        {
            var All = db.Subscriptions.Select(a => a);
            return All;
        }
        public Subscriptions GetById(int id)
        {
            var data = db.Subscriptions.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Subscriptions obj)
        {
            db.Subscriptions.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Subscriptions obj)
        {
            var olddata = db.Subscriptions.Find(obj.Id);
            db.Subscriptions.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Subscriptions obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
