using CodeCloude.Data;
using CodeCloude.Models;

using CodeCloude.Data;
using CodeCloude.Data.Entities;
using Helper;

namespace CodeCloude.Api.Bll
{
    public class SubscripeRequestsApiRep : ISubscripeRequestsApiRep
    {
        private readonly CodeCloude_DbContext db;
        public SubscripeRequestsApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
    
        public void Creat(SubscripeRequestsVM obj)
        {
            SubscripeRequests str = new SubscripeRequests();

            if (obj.Photo != null)
            {
                var img = UploadCv.uploadFile("Uploads/SubscripeRequests", obj.Photo);
                str.imgUrl = img;
            }
            str.Id = obj.Id;
            str.ApplicationUserId = obj.ApplicationUserId;

            str.SubscriptionId = obj.SubscriptionId;

            db.SubscripeRequests.Add(str);
            db.SaveChanges();

        }

    }
    public interface ISubscripeRequestsApiRep
    {
        public void Creat(SubscripeRequestsVM obj);


    }
}