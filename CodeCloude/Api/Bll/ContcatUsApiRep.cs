using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class ContcatUsApiRep : IContcatUsApiRep
    {
        private readonly CodeCloude_DbContext db;
        public ContcatUsApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<ContcatUsVM> GetAll()
        {

            var data = db.ContcatUs.Select(a => new ContcatUsVM
            {

                Id = a.Id,
                About_App = a.About_App,
                Our_Vision = a.Our_Vision,
                Our_Goals = a.Our_Goals,
                Faceebokk_Link = a.Faceebokk_Link,
                Insat_Link = a.Insat_Link,
                Twitter_Link = a.Twitter_Link,
                LinkdLin_Link = a.LinkdLin_Link,

            });

            return data;

        }
    }
    public interface IContcatUsApiRep
    {
        IEnumerable<ContcatUsVM> GetAll();


    }


}

