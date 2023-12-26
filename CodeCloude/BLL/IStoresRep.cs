using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;
using CodeCloude.Models;

namespace CodeCloude.BLL
{
    public interface IStoresRep
    {
        
        IEnumerable<Stores> Get();
        Stores GetById(int id);
        void Creat(Stores obj);
        void Edite(Stores obj);
        void Delete(Stores obj);
         void EditeSpecial(AddspecialModel obj);

    }
    public class StoresRep : IStoresRep
    {
        private readonly CodeCloude_DbContext db;
        public StoresRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Stores> Get()
        {
            var All = db.Stores.Select(a => a).Include("Countries").Include("Categories");
            return All;
        }
        public Stores GetById(int id)
        {
            var data = db.Stores.Where(x => x.Id == id).Include("Countries").Include("Categories").FirstOrDefault();
            return data;
        }

        public void Creat(Stores obj)
        {
            db.Stores.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Stores obj)
        {
            var olddata = db.Stores.Find(obj.Id);
            db.Stores.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Stores obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void EditeSpecial(AddspecialModel obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
