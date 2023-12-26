using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface IContcatUsRep
    {
        IEnumerable<ContcatUs> Get();
        ContcatUs GetById(int id);
        void Creat(ContcatUs obj);
        void Edite(ContcatUs obj); 
        void Delete(ContcatUs obj);
    }
    public class ContcatUsRep : IContcatUsRep
    {
        private readonly CodeCloude_DbContext db;
        public ContcatUsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<ContcatUs> Get()
        {
            var All = db.ContcatUs.Select(a => a);
            return All;
        }
        public ContcatUs GetById(int id)
        {
            var data = db.ContcatUs.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(ContcatUs obj)
        {
            db.ContcatUs.Add(obj);
            db.SaveChanges();

        }

        public void Delete(ContcatUs obj)
        {
            var olddata = db.ContcatUs.Find(obj.Id);
            db.ContcatUs.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(ContcatUs obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}