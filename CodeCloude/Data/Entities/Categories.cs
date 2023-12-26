namespace CodeCloude.Data.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public String Categ_Name { get; set; }
        public String Cated_IconUrl { get; set; }

        //relations

        public virtual List<Stores> Stores { get; set; }


    }
}
