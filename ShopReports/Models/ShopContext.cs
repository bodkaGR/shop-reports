using Microsoft.EntityFrameworkCore;

namespace ShopReports.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(p => p.Person)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductTitle> Titles { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<SupermarketLocation> SupermarketLocations { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonContact> PersonContacts { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
