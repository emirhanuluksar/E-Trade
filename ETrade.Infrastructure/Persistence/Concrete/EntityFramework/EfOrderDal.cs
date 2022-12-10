using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccess.EntityFramework;
using Application.DTOs;
using Domain.Entities.Concrete;
using Persistence.Abstract;

namespace Persistence.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ETradeContext>, IOrderDal
    {
        public List<OrderDetailsDto> GetOrderDetail(int customerId)
        {
            using(ETradeContext context = new ETradeContext())
            {
                var result = from o in context.Orders
                             join c in context.Customers
                             on o.CustomerId equals c.CustomerId
                             join s in context.Stores
                             on o.ProductId equals s.StoreId
                            //  join ct in context.Categories
                            //  on o.CategoryId equals ct.CategoryId
                             join p in context.Products
                             on o.ProductId equals p.ProductId
                             where o.CustomerId == customerId

                             select new OrderDetailsDto {OrderId=o.OrderId, StoreName=s.StoreName,ProductName=p.ProductName,CustomerName=c.FirstName + " " + c.LastName, OrderDate=DateTime.Now};
                return result.ToList();
            }
        }
    }
}