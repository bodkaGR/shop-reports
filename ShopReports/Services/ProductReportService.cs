using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services
{
    public class ProductReportService
    {
        private readonly ShopContext shopContext;

        public ProductReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public ProductCategoryReport GetProductCategoryReport()
        {
            var report = this.shopContext.Categories.Select(
                category => new ProductCategoryReportLine
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                })
            .OrderBy(category => category.CategoryName).ToList();

            return new ProductCategoryReport(report, DateTime.Now);
        }

        public ProductReport GetProductReport()
        {
            IQueryable<ProductReportLine> query = from title in this.shopContext.Titles
                join product in this.shopContext.Products on title.Id equals product.TitleId
                join manufacturers in this.shopContext.Manufacturers on product.ManufacturerId equals manufacturers.Id
                select new ProductReportLine
                {
                    ProductId = product.Id,
                    ProductTitle = title.Title,
                    Manufacturer = manufacturers.Name,
                    Price = product.UnitPrice,
                };

            var productsReports = query.OrderByDescending(product => product.ProductTitle).ToList();

            return new ProductReport(productsReports, DateTime.Now);
        }

        public FullProductReport GetFullProductReport()
        {
            var query = from title in this.shopContext.Titles
                join category in this.shopContext.Categories on title.CategoryId equals category.Id
                join product in this.shopContext.Products on title.Id equals product.TitleId
                join manufacturer in this.shopContext.Manufacturers on product.ManufacturerId equals manufacturer.Id
                select new FullProductReportLine
                {
                    ProductId = product.Id,
                    Name = title.Title,
                    CategoryId = category.Id,
                    Manufacturer = manufacturer.Name,
                    Price = product.UnitPrice,
                    Category = category.Name,
                };

            var fullOrderedProducts = query.OrderBy(product => product.Name).ToList();

            return new FullProductReport(fullOrderedProducts, DateTime.Now);
        }

        public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
        {
            var query = from title in this.shopContext.Titles
                join product in this.shopContext.Products on title.Id equals product.TitleId
                join orderDetail in this.shopContext.OrderDetails on product.Id equals orderDetail.ProductId
                group orderDetail by title.Title
                into orderGroup
                select new ProductTitleSalesRevenueReportLine
                {
                    ProductTitleName = orderGroup.Key,
                    SalesRevenue = orderGroup.Sum(od => od.PriceWithDiscount),
                    SalesAmount = orderGroup.Sum(od => od.ProductAmount),
                };

            var sortedTitlesSalesRevenueReport = query.OrderByDescending(title => title.SalesRevenue).ToList();

            return new ProductTitleSalesRevenueReport(sortedTitlesSalesRevenueReport, DateTime.Now);
        }
    }
}
