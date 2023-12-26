using CodeCloude.Data;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using Helper;

namespace CodeCloude.Api.Bll
{
    
    public class StoresApiRep : IStoresApiRep
    {
        private readonly CodeCloude_DbContext db;
        public StoresApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<StoresVM>> SearchStores(string Search)
        {

            var data = db.Stores.Select(a => new StoresVM
            {

                Id = a.Id,
                Stor_Title = a.Stor_Title,
                Stor_Address = a.Stor_Address,
                isFaviourite=a.isFaviourite,
                Stor_Link = a.Stor_Link,
                Stor_Offer = a.Stor_Offer,
                Stor_PhoneNumber = a.Stor_PhoneNumber,
                IsSpecial = a.IsSpecial,

                Stor_Deteils = a.Stor_Deteils,
                Stor_SaleCode = a.Stor_SaleCode,
                User_Faviourites=a.User_Faviourites,
                CatgId = a.CatgId,

                CountId = a.CountId,
                Categories = a.Categories,

                Countries = a.Countries,
                Stor_ImgUrl = "/Uploads/Stores/" + a.Stor_ImgUrl,
            }).Where(a => a.Stor_Title.Contains(Search) ||
                a.Stor_Deteils.Contains(Search) ||
                a.Stor_PhoneNumber.Contains(Search) ||
                a.Stor_SaleCode.Contains(Search)
                );

            return data;

        }

        public IEnumerable<StoresVM> GetAll(int count_id)
        {

            var data = db.Stores.Select(a => new StoresVM
            {

                Id = a.Id,
                Stor_Title = a.Stor_Title,
                Stor_Address = a.Stor_Address,
                IsSpecial = a.IsSpecial,
                isFaviourite = a.isFaviourite,

                Stor_Link = a.Stor_Link,
                Stor_Offer = a.Stor_Offer,
                Stor_PhoneNumber = a.Stor_PhoneNumber,

                Stor_Deteils = a.Stor_Deteils,
                Stor_SaleCode = a.Stor_SaleCode,

                CatgId = a.CatgId,

                CountId = a.CountId,
                Categories = a.Categories,
                User_Faviourites = a.User_Faviourites,

                Countries = a.Countries,
                Stor_ImgUrl = "/Uploads/Stores/" + a.Stor_ImgUrl,
            }).Where(a => a.CountId == count_id);

            return data;

        }
        public IEnumerable<StoresVM> GetAllSpecial()
        {

            var data = db.Stores.Select(a => new StoresVM
            {

                Id = a.Id,

                
                Stor_Title = a.Stor_Title,
                Stor_Address = a.Stor_Address,
                IsSpecial = a.IsSpecial,
                isFaviourite = a.isFaviourite,
                User_Faviourites = a.User_Faviourites,

                Stor_Link = a.Stor_Link,
                Stor_Offer = a.Stor_Offer,
                Stor_PhoneNumber = a.Stor_PhoneNumber,

                Stor_Deteils = a.Stor_Deteils,
                Stor_SaleCode = a.Stor_SaleCode,
                CatgId = a.CatgId,

                CountId = a.CountId,

                Stor_ImgUrl = "/Uploads/Stores/" + a.Stor_ImgUrl,
            });

            return data;

        }

        public async Task<IEnumerable<StoresVM>> GetByCategId(int CategId)
        {
            var data = db.Stores.Where(a=>a.CatgId== CategId).Select(a => new StoresVM
            {

                Id = a.Id,
                Stor_Title = a.Stor_Title,
                Stor_PhoneNumber = a.Stor_PhoneNumber,
                Stor_Address = a.Stor_Address,
                isFaviourite = a.isFaviourite,

                Stor_Link = a.Stor_Link,
                Stor_Offer = a.Stor_Offer,

                Stor_Deteils = a.Stor_Deteils,
                Stor_SaleCode = a.Stor_SaleCode,

                CatgId = a.CatgId,

                CountId = a.CountId,
                Categories = a.Categories,
                User_Faviourites = a.User_Faviourites,
                IsSpecial=a.IsSpecial,

                Countries = a.Countries,
                Stor_ImgUrl = "/Uploads/Stores/" + a.Stor_ImgUrl,
            });
            return data;
        }
        public Stores Creat(StoresVM obj)
        {
            Stores str = new Stores();

            if (obj.Photo != null)
            {
                var img = UploadCv.uploadFile("Uploads/Stores", obj.Photo);
                str.Stor_ImgUrl = img;
            }
                str.Id = obj.Id;
                str.Stor_Title = obj.Stor_Title;
               str.Stor_Address = obj.Stor_Address;

                str.Stor_Link = obj.Stor_Link;
                str.Stor_Offer = obj.Stor_Offer;
                str.Stor_PhoneNumber = obj.Stor_PhoneNumber;

                str.Stor_Deteils = obj.Stor_Deteils;
                str.Stor_SaleCode = obj.Stor_SaleCode;

                str.CatgId = obj.CatgId;

                str.CountId = obj.CountId;

            db.Stores.Add(str);
            db.SaveChanges();

            var data = db.Stores.OrderBy(a => a.Id).LastOrDefault();
            return data;
        }
        public StoresVM GetById(int id)
        {

            var data = db.Stores.Where(a => a.Id == id).Select(a => new StoresVM
            {

                Id = a.Id,
                Stor_Title = a.Stor_Title,
                Stor_Address = a.Stor_Address,
                IsSpecial = a.IsSpecial,
                isFaviourite = a.isFaviourite,

                Stor_Link = a.Stor_Link,
                Stor_Offer = a.Stor_Offer,
                Stor_PhoneNumber = a.Stor_PhoneNumber,

                Stor_Deteils = a.Stor_Deteils,
                Stor_SaleCode = a.Stor_SaleCode,

                CatgId = a.CatgId,

                CountId = a.CountId,
                Categories = a.Categories,

                Countries = a.Countries,
                Stor_ImgUrl = "/Uploads/Stores/" + a.Stor_ImgUrl,
            }).FirstOrDefault();

            return data;

        }

    }
    public interface IStoresApiRep
    {
        Task<IEnumerable<StoresVM>> SearchStores(string Search);
        IEnumerable<StoresVM> GetAll(int count_id);
        Task<IEnumerable<StoresVM>> GetByCategId(int Id);
        public Stores Creat(StoresVM obj);

        public StoresVM GetById(int id);
        public IEnumerable<StoresVM> GetAllSpecial();

    }
}