using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services
{
    public class CustomerReportService
    {
        private readonly ShopContext shopContext;

        public CustomerReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
        {
            IQueryable<CustomerSalesRevenueReportLine> query = from customer in this.shopContext.Customers
                        join order in this.shopContext.Orders on customer.Id equals order.CustomerId
                        join orderDetail in this.shopContext.OrderDetails on order.Id equals orderDetail.OrderId
                        group orderDetail by new { customer.Id, customer.Person.FirstName, customer.Person.LastName } into customerGroup
                        select new CustomerSalesRevenueReportLine
                        {
                            CustomerId = customerGroup.Key.Id,
                            PersonFirstName = customerGroup.Key.FirstName,
                            PersonLastName = customerGroup.Key.LastName,
                            SalesRevenue = customerGroup.Sum(od => od.PriceWithDiscount),
                        };

            var sortedQuery = query.OrderByDescending(reportLine => reportLine.SalesRevenue).ToList();

            return new CustomerSalesRevenueReport(sortedQuery, DateTime.Now);
        }
    }
}
