using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface IUser_FaviouritesRep
    {
        IEnumerable<User_Faviourites> Get();
        User_Faviourites GetById(int id);
        void Creat(User_Faviourites obj);
        void Edite(User_Faviourites obj);
        void Delete(User_Faviourites obj);
    }
    public class User_FaviouritesRep : IUser_FaviouritesRep
    {
        private readonly CodeCloude_DbContext db;
        public User_FaviouritesRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<User_Faviourites> Get()
        {
            var All = db.User_Faviourites.Select(a => a);
            return All;
        }
        public User_Faviourites GetById(int id)
        {
            var data = db.User_Faviourites.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(User_Faviourites obj)
        {
            db.User_Faviourites.Add(obj);
            db.SaveChanges();

        }

        public void Delete(User_Faviourites obj)
        {
            var olddata = db.User_Faviourites.Find(obj.Id);
            db.User_Faviourites.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(User_Faviourites obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

