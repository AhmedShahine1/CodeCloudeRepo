using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class privacypolicyApiRep : IprivacypolicyApiRep
    {
        private readonly CodeCloude_DbContext db;
        public privacypolicyApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<privacypolicyVM> GetAll()
        {

            var data = db.privacypolicy.Select(a => new privacypolicyVM
            {

                Id = a.Id,
                Deatils = a.Deatils,

            });

            return data;

        }
    }
    public interface IprivacypolicyApiRep
    {
        IEnumerable<privacypolicyVM> GetAll();


    }


}

