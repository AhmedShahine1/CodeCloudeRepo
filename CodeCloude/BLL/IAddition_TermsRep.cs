using CodeCloude.Data;
using CodeCloude.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface IAddition_TermsRep
    {
        IEnumerable<Addition_Terms> Get();
        Addition_Terms GetById(int id);
        void Creat(Addition_Terms obj);
        void Edite(Addition_Terms obj);
        void Delete(Addition_Terms obj);
    }
    public class Addition_TermsRep : IAddition_TermsRep
    {
        private readonly CodeCloude_DbContext db;
        public Addition_TermsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Addition_Terms> Get()
        {
            var All = db.Addition_Terms.Select(a => a);
            return All;
        }
        public Addition_Terms GetById(int id)
        {
            var data = db.Addition_Terms.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Addition_Terms obj)
        {
            db.Addition_Terms.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Addition_Terms obj)
        {
            var olddata = db.Addition_Terms.Find(obj.Id);
            db.Addition_Terms.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Addition_Terms obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
