using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customer_order_details")]
    public class OrderDetail
    {
        [Key]
        [Column("customer_order_detail_id")]
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Column("customer_order_id")]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("price_with_discount")]
        public double PriceWithDiscount { get; set; }

        [Column("product_amount")]
        public int ProductAmount { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
