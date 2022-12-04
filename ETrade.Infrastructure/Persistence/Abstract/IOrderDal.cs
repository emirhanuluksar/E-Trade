using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DataAccess;
using Application.DTOs;
using Domain.Entities.Concrete;

namespace Persistence.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<OrderDetailsDto> GetOrderDetail(int customerId);
    }
}