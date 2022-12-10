using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities.Concrete;

namespace Infrastructure.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<OrderDetailsDto>> GetCustomerOrders(int customerId);
        IResult CreateOrder(int customerId, Product product, int piece);
    }
}