using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface IprivacypolicyRep
    {
        IEnumerable<privacypolicy> Get();
        privacypolicy GetById(int id);
        void Creat(privacypolicy obj);
        void Edite(privacypolicy obj);
        void Delete(privacypolicy obj);
    }
    public class privacypolicyRep : IprivacypolicyRep
    {
        private readonly CodeCloude_DbContext db;
        public privacypolicyRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<privacypolicy> Get()
        {
            var All = db.privacypolicy.Select(a => a);
            return All;
        }
        public privacypolicy GetById(int id)
        {
            var data = db.privacypolicy.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(privacypolicy obj)
        {
            db.privacypolicy.Add(obj);
            db.SaveChanges();

        }

        public void Delete(privacypolicy obj)
        {
            var olddata = db.privacypolicy.Find(obj.Id);
            db.privacypolicy.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(privacypolicy obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
