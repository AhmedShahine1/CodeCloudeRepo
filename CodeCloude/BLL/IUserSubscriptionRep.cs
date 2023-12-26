using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface IUserSubscriptionRep
    {
        IEnumerable<UserSubscription> Get();
        UserSubscription GetById(int id);
        void Creat(UserSubscription obj);
        void Edite(UserSubscription obj);
        void Delete(UserSubscription obj);
    }
    public class UserSubscriptionRep : IUserSubscriptionRep
    {
        private readonly CodeCloude_DbContext db;
        public UserSubscriptionRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<UserSubscription> Get()
        {
            var All = db.UserSubscription.Select(a => a).Include("ApplicationUser").Include("Subscriptions");
            return All;
        }
        public UserSubscription GetById(int id)
        {
            var data = db.UserSubscription.Where(x => x.Id == id).Include("ApplicationUser").Include("Subscriptions").FirstOrDefault();
            return data;
        }

        public void Creat(UserSubscription obj)
        {
            db.UserSubscription.Add(obj);
            db.SaveChanges();

        }

        public void Delete(UserSubscription obj)
        {
            var olddata = db.UserSubscription.Find(obj.Id);
            db.UserSubscription.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(UserSubscription obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

