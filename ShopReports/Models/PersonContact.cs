using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("person_contacts")]
    public class PersonContact
    {
        [Key]
        [Column("person_contact_id")]
        public int Id { get; set; }

        [ForeignKey("Person")]
        [Column("person_id")]
        public int PersonId { get; set; }

        [ForeignKey("ContactType")]
        [Column("contact_type_id")]
        public int ContactTypeId { get; set; }

        [Column("contact_value")]
        public string Value { get; set; }

        public Person Person { get; set; }

        public ContactType Type { get; set; }
    }
}
