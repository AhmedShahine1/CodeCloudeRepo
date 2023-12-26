using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class CategoriesApiRep : ICategoriesApiRep
    {
        private readonly CodeCloude_DbContext db;
        public CategoriesApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CategoriesVM> GetAll()
        {

            var data = db.Categories.Select(a => new CategoriesVM
            {

                Id = a.Id,
                Categ_Name = a.Categ_Name,

                Cated_IconUrl = "/Uploads/Categories/" + a.Cated_IconUrl,
            });

            return data;

        }


        
    }
    public interface ICategoriesApiRep
    {
        IEnumerable<CategoriesVM> GetAll();


    }
}