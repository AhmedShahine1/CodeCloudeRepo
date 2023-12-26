using CodeCloude.Data.Entities;
using CodeCloude.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.BLL
{
    
    public interface IBankDetailsRep
    {
        IEnumerable<BankDetails> Get();
        BankDetails GetById(int id);
        void Creat(BankDetails obj);
        void Edite(BankDetails obj);
        void Delete(BankDetails obj);
    }
    public class BankDetailsRep : IBankDetailsRep
    {
        private readonly CodeCloude_DbContext db;
        public BankDetailsRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<BankDetails> Get()
        {
            var All = db.BankDetails.Select(a => a);
            return All;
        }
        public BankDetails GetById(int id)
        {
            var data = db.BankDetails.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(BankDetails obj)
        {
            db.BankDetails.Add(obj);
            db.SaveChanges();

        }

        public void Delete(BankDetails obj)
        {
            var olddata = db.BankDetails.Find(obj.Id);
            db.BankDetails.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(BankDetails obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
