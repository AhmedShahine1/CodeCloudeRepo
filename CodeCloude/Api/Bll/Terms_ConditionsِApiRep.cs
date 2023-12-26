using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class Terms_ConditionsApiRep : ITerms_ConditionsApiRep
    {
        private readonly CodeCloude_DbContext db;
        public Terms_ConditionsApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Terms_ConditionsVM> GetAll()
        {

            var data = db.Terms_Conditions.Select(a => new Terms_ConditionsVM
            {

                Id = a.Id,
                Details = a.Details,

            });

            return data;

        }
    }
    public interface ITerms_ConditionsApiRep
    {
        IEnumerable<Terms_ConditionsVM> GetAll();


    }


}

