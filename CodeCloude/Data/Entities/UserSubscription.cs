using CodeCloude.Extend;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCloude.Data.Entities
{
    public class UserSubscription
    {
        [Key]
        public int Id { get; set; }
        public DateTime SubscriptionDate { get; set; } 
        public int SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        public Subscriptions? Subscriptions { get; set; }


        public string ApplicationUserId { get; set; }
        public virtual  ApplicationUser? ApplicationUser { get; set; }


    }
}
