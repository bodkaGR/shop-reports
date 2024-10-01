using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("location_city")]
    public class City
    {
        [Key]
        [Column("city_id")]
        public int Id { get; set; }

        [Column("city")]
        public string Name { get; set; }

        [Column("country")]
        public string Country { get; set; }

        public virtual IList<Location> Locations { get; set; }
    }
}
