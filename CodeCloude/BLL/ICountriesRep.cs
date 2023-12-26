using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface ICountriesRep
    {
        
        IEnumerable<Countries> Get();
        Countries GetById(int id);
        void Creat(Countries obj);
        void Edite(Countries obj);
        void Delete(Countries obj);
    }
    public class CountriesRep : ICountriesRep
    {
        private readonly CodeCloude_DbContext db;
        public CountriesRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Countries> Get()
        {
            var All = db.Countries.Select(a => a).Include("Stores");
            return All;
        }
        public Countries GetById(int id)
        {
            var data = db.Countries.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Countries obj)
        {
            db.Countries.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Countries obj)
        {
            var olddata = db.Countries.Find(obj.Id);
            db.Countries.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Countries obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
