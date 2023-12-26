using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface ICategoriesRep
    {
        IEnumerable<Categories> Get();
        Categories GetById(int id);
        void Creat(Categories obj);
        void Edite(Categories obj);
        void Delete(Categories obj);
    }
    public class CategoriesRep : ICategoriesRep
    {
        private readonly CodeCloude_DbContext db;
        public CategoriesRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Categories> Get()
        {
            var All = db.Categories.Select(a => a).Include("Stores");
            return All;
        }
        public Categories GetById(int id)
        {
            var data = db.Categories.Where(x => x.Id == id).Include("Stores").FirstOrDefault();
            return data;
        }

        public void Creat(Categories obj)
        {
            db.Categories.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Categories obj)
        {
            var olddata = db.Categories.Find(obj.Id);
            db.Categories.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Categories obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
