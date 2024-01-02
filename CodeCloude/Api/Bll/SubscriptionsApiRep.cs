using CodeCloude.Data;
using CodeCloude.Data.Entities;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class SubscriptionsApiRep : ISubscriptionsApiRep
    {
        private readonly CodeCloude_DbContext db;
        public SubscriptionsApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        
        public IEnumerable<SubscriptionsVM> GetAll()
        {

            var data = db.Subscriptions.Select(a => new SubscriptionsVM
            {

                Id = a.Id,
                Subscription_Title = a.Subscription_Title,
                Subscription_Period = a.Subscription_Period,
                Ads_Number = a.Ads_Number,
                ImgUrl = "/Uploads/Subscriptions/"+a.ImgUrl,
            });

            return data;

        }

        public IEnumerable<Subscriptions> GetById(string id)
        {

            var data = db.Subscriptions.Where(s => s.Id == Int64.Parse(id)).ToList();
            return data;

        }

    }
    public interface ISubscriptionsApiRep
    {
        IEnumerable<SubscriptionsVM> GetAll();
        IEnumerable<Subscriptions> GetById(string id);

    }


}

