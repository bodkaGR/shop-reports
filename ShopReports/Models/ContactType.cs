using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("contact_types")]
    public class ContactType
    {
        [Key]
        [Column("contact_type_id")]
        public int Id { get; set; }

        [Column("contact_type_name")]
        public string Name { get; set; }

        public virtual IList<PersonContact> Contacts { get; set; }
    }
}
