using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCloude.Data.Entities
{
    public class Stores
    {
        public int Id { get; set; }
        public String Stor_Title { get; set; }
        public String? Stor_ImgUrl { get; set; }
        public String Stor_Link { get; set; }
        public String Stor_Deteils { get; set; }
        public String Stor_Offer { get; set; }
        public string Stor_SaleCode { get; set; }
        public string Stor_Address { get; set; }
        public string Stor_PhoneNumber { get; set; }
        public bool IsSpecial { get; set; } = false;
        //relations
        public bool isFaviourite { get; set; }
        //Categories
        public int CatgId { get; set; }

        [ForeignKey("CatgId")]
        public virtual Categories? Categories { get; set; }

        //Countries
        public int CountId { get; set; }
        [ForeignKey("CountId")]
        public virtual Countries? Countries { get; set; }
        //Faviourities
       
        public virtual List<User_Faviourites> User_Faviourites { get; set; }
    }
}
