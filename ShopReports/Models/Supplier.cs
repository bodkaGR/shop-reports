using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("product_suppliers")]
    public class Supplier
    {
        [Key]
        [Column("supplier_id")]
        public int Id { get; set; }

        [Column("supplier_name")]
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
