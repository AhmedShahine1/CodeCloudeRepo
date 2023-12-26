using CodeCloude.Extend;
using System.ComponentModel.DataAnnotations;

namespace CodeCloude.Data.Entities
{
    public class Countries
    {
        [Key]
        public int Id { get; set; }

        public string Cont_Name { get; set; }
        public string Cont_FlagUrl { get; set; }

        //relations

        public virtual ICollection<Stores> Stores { get; set; }
    }
}
