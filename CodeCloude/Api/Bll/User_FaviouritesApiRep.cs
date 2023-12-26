using CodeCloude.Data.Entities;
using CodeCloude.Data;
using CodeCloude.Models;
using Helper;
using Microsoft.EntityFrameworkCore;

namespace CodeCloude.Api.Bll
{
    public class User_FaviouritesApiRep : IUser_FaviouritesApiRep
    {
        private readonly CodeCloude_DbContext db;
        public User_FaviouritesApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        

        public void Creat(User_FaviouritesVM obj )
        {
            User_Faviourites str = new User_Faviourites();
            str.Id = obj.Id;
            str.userId = obj.userId;

            str.storeId = obj.storeId;

            db.User_Faviourites.Add(str);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var oldData = db.User_Faviourites.Find(id);
            db.User_Faviourites.Remove(oldData);
            db.SaveChanges();
        }
        public void DeleteFav(string UserId, int productId)
        {
            var oldData = db.User_Faviourites.Where(a => a.userId == UserId && a.storeId == productId).FirstOrDefault();
            db.User_Faviourites.Remove(oldData);
            db.SaveChanges();
        }

        public IEnumerable<StoresVM>  GetById(string Userid)
        {

            var data = db.User_Faviourites.Where(a => a.userId == Userid)
                .Select(a => new StoresVM
                {
                    Id = a.Stores.Id,
                    User_Faviourite_Id = a.Id,

                    Stor_Address = a.Stores.Stor_Address,
                    Stor_Title = a.Stores.Stor_Title,
                    IsSpecial = a.Stores.IsSpecial,
                    isFaviourite = true,

                    Stor_Link = a.Stores.Stor_Link,
                    Stor_Offer = a.Stores.Stor_Offer,
                    Stor_PhoneNumber = a.Stores.Stor_PhoneNumber,

                    Stor_Deteils = a.Stores.Stor_Deteils,
                    Stor_SaleCode = a.Stores.Stor_SaleCode,

                    CatgId = a.Stores.CatgId,

                    CountId = a.Stores.CountId,
                    Categories = a.Stores.Categories,
                    Countries = a.Stores.Countries,
                    Stor_ImgUrl = "/Uploads/Stores/" + a.Stores.Stor_ImgUrl,
                });

            return data;

        }
        public async Task<IEnumerable<StoresVM>> GetByuser_storeId(string Userid , int storeId)
        {

            var data = db.User_Faviourites.Where(a => a.userId == Userid && a.storeId==storeId).Select(a => new StoresVM
            {

                Id = a.Stores.Id,
                User_Faviourite_Id = a.Id,


                Stor_Address = a.Stores.Stor_Address,
                Stor_Title = a.Stores.Stor_Title,
                IsSpecial = a.Stores.IsSpecial,
                isFaviourite = true,
                Stor_Link = a.Stores.Stor_Link,
                Stor_Offer = a.Stores.Stor_Offer,
                Stor_PhoneNumber = a.Stores.Stor_PhoneNumber,

                Stor_Deteils = a.Stores.Stor_Deteils,
                Stor_SaleCode = a.Stores.Stor_SaleCode,

                CatgId = a.Stores.CatgId,

                CountId = a.Stores.CountId,
                Categories = a.Stores.Categories,
                Countries = a.Stores.Countries,
                
                Stor_ImgUrl = "/Uploads/Stores/" + a.Stores.Stor_ImgUrl,
            });
            return data;
        }

    }
    public interface IUser_FaviouritesApiRep
    {
         Task<IEnumerable<StoresVM>> GetByuser_storeId(string Userid, int storeId);
        public void Delete(int id);
        public void Creat(User_FaviouritesVM obj);
        public IEnumerable<StoresVM> GetById(string Userid);
        public void DeleteFav(string UserId, int productId);
    }
}