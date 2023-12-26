using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class Addition_TermsApiRep : IAddition_TermsApiRep
    {
        private readonly CodeCloude_DbContext db;
    public Addition_TermsApiRep(CodeCloude_DbContext db)
    {
        this.db = db;
    }
    public IEnumerable<Addition_TermsVM> GetAll()
    {

            var data = db.Addition_Terms.Select(a => new Addition_TermsVM
            {

                Id = a.Id,
                Details = a.Details,

            });

            return data;

        }
    }
    public interface IAddition_TermsApiRep
    {
        IEnumerable<Addition_TermsVM> GetAll();


    }


}

