using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("product_titles")]
    public class ProductTitle
    {
        [Key]
        [Column("product_title_id")]
        public int Id { get; set; }

        [Column("product_title")]
        public string Title { get; set; }

        [ForeignKey("Category")]
        [Column("product_category_id")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
