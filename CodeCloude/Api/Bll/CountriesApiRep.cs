using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    
    public class CountriesApiRep : ICountriesApiRep
    {
        private readonly CodeCloude_DbContext db;
        public CountriesApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CountriesVM> GetAll()
        {

            var data = db.Countries.Select(a => new CountriesVM
            {

                Id = a.Id,
                Cont_Name = a.Cont_Name,
                Cont_FlagUrl = "/Uploads/Countries/" + a.Cont_FlagUrl,
            });

            return data;

        }



    }
    public interface ICountriesApiRep
    {
        IEnumerable<CountriesVM> GetAll();


    }
}