using System.ComponentModel.DataAnnotations;

namespace CodeCloude.Data.Entities
{
    public class Subscriptions
    {
        [Key]
        public int Id { get; set; }
        public string Subscription_Title { get; set; }
        public string Ads_Number { get; set; }
        public string Subscription_Period { get; set; }
        public string ImgUrl { get; set; }
        public List<UserSubscription> UserSubscription { get; set; }
    }
}
