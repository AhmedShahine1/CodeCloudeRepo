using CodeCloude.Extend;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCloude.Data.Entities
{
    public class SubscripeRequests
    {
        public int Id { get; set; }
        public string? imgUrl { get; set; }
        public bool? IsAccepted { get; set; } = false;

        public int SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        public Subscriptions? Subscriptions { get; set; }


        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

    }
}
