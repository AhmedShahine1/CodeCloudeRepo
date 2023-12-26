using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCloude.Data.Entities
{
    public class User_Faviourites
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public int storeId { get; set; }

        [ForeignKey("storeId")]
        public Stores? Stores { get; set; }
    }
}
