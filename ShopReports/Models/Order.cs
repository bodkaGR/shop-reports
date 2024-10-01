using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customer_orders")]
    public class Order
    {
        [Key]
        [Column("customer_order_id")]
        public int Id { get; set; }

        [Column("operation_time")]
        public string OperationTime { get; set; }

        [ForeignKey("SupermarketLocation")]
        [Column("supermarket_location_id")]
        public int SupermarketLocationId { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int? CustomerId { get; set; }

        public SupermarketLocation SupermarketLocation { get; set; }

        public Customer? Customer { get; set; }

        public virtual IList<OrderDetail> Details { get; set; }
    }
}
