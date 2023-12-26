namespace CodeCloude.Models
{
    public class AddUserSubscriptionModel
    {
        public string userId { get; set; }
        public bool IsSubscriped { get; set; }
        public string? SubscriptionName { get; set; }
    }
}
