//using CodeCloude.Data.Entities;
//using CodeCloude.Data;
//using CodeCloude.Models;
//using Helper;

//namespace CodeCloude.Api.Bll
//{
//    public class UserSubscriptionApiRep : IUserSubscriptionApiRep
//    {
//        private readonly CodeCloude_DbContext db;
//        public UserSubscriptionApiRep(CodeCloude_DbContext db)
//        {
//            this.db = db;
//        }
//        public IEnumerable<UserSubscriptionVM> SearchUserSubscription(string Search)
//        {

//            var data = db.UserSubscription.Select(a => new UserSubscriptionVM
//            {

//                Id = a.Id,
              
//            });

//            return data;

//        }

//        public IEnumerable<UserSubscriptionVM> GetAll()
//        {

//            var data = db.UserSubscription.Select(a => new UserSubscriptionVM
//            {

//                Id = a.Id,
      
//            });

//            return data;

//        }


//        public IEnumerable<UserSubscriptionVM> GetByCategId(int CategId)
//        {
//            var data = db.UserSubscription.Where(a => a).Select(a => new UserSubscriptionVM
//            {

//                Id = a.Id,
      
//            });
//            return data;
//        }
//        public UserSubscription Creat(UserSubscriptionVM obj)
//        {
//            UserSubscription str = new UserSubscription();

//            if (obj.Photo != null)
//            {
//                var img = UploadCv.uploadFile("Uploads/UserSubscription", obj.Photo);
//                str.Stor_ImgUrl = img;
//            }
//            str.Id = obj.Id;
//            str.Stor_Title = obj.Stor_Title;

//            str.Stor_Link = obj.Stor_Link;
//            str.Stor_Offer = obj.Stor_Offer;
//            str.Stor_PhoneNumber = obj.Stor_PhoneNumber;

//            str.Stor_Deteils = obj.Stor_Deteils;
//            str.Stor_SaleCode = obj.Stor_SaleCode;

//            str.Accept_Loco_Card = obj.Accept_Loco_Card;
//            str.CatgId = obj.CatgId;

//            str.CountId = obj.CountId;

//            db.UserSubscription.Add(str);
//            db.SaveChanges();

//            var data = db.UserSubscription.OrderBy(a => a.Id).LastOrDefault();
//            return data;
//        }
        
//        public UserSubscriptionVM GetById(int id)
//        {

//            var data = db.UserSubscription.Where(a => a.Id == id).Select(a => new UserSubscriptionVM
//            {

//                Id = a.Id,
//                Stor_Title = a.Stor_Title,

//                Stor_Link = a.Stor_Link,
//                Stor_Offer = a.Stor_Offer,
//                Stor_PhoneNumber = a.Stor_PhoneNumber,

//                Stor_Deteils = a.Stor_Deteils,
//                Stor_SaleCode = a.Stor_SaleCode,

//                Accept_Loco_Card = a.Accept_Loco_Card,
//                CatgId = a.CatgId,

//                CountId = a.CountId,
//                Categories = a.Categories,

//                Countries = a.Countries,
//                Stor_ImgUrl = "/Uploads/UserSubscription/" + a.Stor_ImgUrl,
//            }).FirstOrDefault();

//            return data;

//        }

//    }
//    public interface IUserSubscriptionApiRep
//    {
//        IEnumerable<UserSubscriptionVM> SearchUserSubscription(string Search);
//        IEnumerable<UserSubscriptionVM> GetAll();
//        IEnumerable<UserSubscriptionVM> GetByCategId(int Id);
//        public UserSubscription Creat(UserSubscriptionVM obj);

//        public UserSubscriptionVM GetById(int id);

//    }
//}