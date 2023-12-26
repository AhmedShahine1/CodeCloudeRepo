using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface ITerms_ConditionsRep
    {
        
        IEnumerable<Terms_Conditions> Get();
        Terms_Conditions GetById(int id);
        void Creat(Terms_Conditions obj);
        void Edite(Terms_Conditions obj);
        void Delete(Terms_Conditions obj);
    }
    public class Terms_ConditionsRep : ITerms_ConditionsRep
    {
        private readonly CodeCloude_DbContext db;
        public Terms_ConditionsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Terms_Conditions> Get()
        {
            var All = db.Terms_Conditions.Select(a => a);
            return All;
        }
        public Terms_Conditions GetById(int id)
        {
            var data = db.Terms_Conditions.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Terms_Conditions obj)
        {
            db.Terms_Conditions.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Terms_Conditions obj)
        {
            var olddata = db.Terms_Conditions.Find(obj.Id);
            db.Terms_Conditions.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Terms_Conditions obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
