using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface ISliderRep
    {
        
        IEnumerable<Slider> Get();
        Slider GetById(int id);
        void Creat(Slider obj);
        void Edite(Slider obj);
        void Delete(Slider obj);
    }
    public class SliderRep : ISliderRep
    {
        private readonly CodeCloude_DbContext db;
        public SliderRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Slider> Get()
        {
            var All = db.Slider.Select(a => a);
            return All;
        }
        public Slider GetById(int id)
        {
            var data = db.Slider.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Slider obj)
        {
            db.Slider.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Slider obj)
        {
            var olddata = db.Slider.Find(obj.Id);
            db.Slider.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Slider obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
