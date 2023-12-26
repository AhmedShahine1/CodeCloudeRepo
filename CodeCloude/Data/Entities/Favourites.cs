using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCloude.Data.Entities
{
    public class Favourites
    {
        public int Id { get; set; }

        public int storeId { get; set; }
        [ForeignKey("stroeId")]
        public virtual Stores Stores { get; set; }
    }
}
