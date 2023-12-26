
using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    public interface IQuestionsRep
    {
        
        IEnumerable<Questions> Get();
        Questions GetById(int id);
        void Creat(Questions obj);
        void Edite(Questions obj);
        void Delete(Questions obj);
    }
    public class QuestionsRep : IQuestionsRep
    {
        private readonly CodeCloude_DbContext db;
        public QuestionsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Questions> Get()
        {
            var All = db.Questions.Select(a => a);
            return All;
        }
        public Questions GetById(int id)
        {
            var data = db.Questions.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Questions obj)
        {
            db.Questions.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Questions obj)
        {
            var olddata = db.Questions.Find(obj.Id);
            db.Questions.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Questions obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
