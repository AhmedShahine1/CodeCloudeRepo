using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class BankDetailsApiRep : IBankDetailsApiRep
    {
        private readonly CodeCloude_DbContext db;
        public BankDetailsApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<BankDetailsVM> GetAll()
        {

            var data = db.BankDetails.Select(a => new BankDetailsVM
            {

                Id = a.Id,
                accountNumber = a.accountNumber,

            });

            return data;

        }
    }
    public interface IBankDetailsApiRep
    {
        IEnumerable<BankDetailsVM> GetAll();


    }


}

