using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;

namespace Infrastructure.Concrete
{
    public class CustomerManager : ICustomerService
    {
        IOrderService _orderService;

        public CustomerManager(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IDataResult<List<OrderDetailsDto>> GetMyOrders(int customerId)
        {
            var result = _orderService.GetCustomerOrders(customerId);
            return new SuccessDataResult<List<OrderDetailsDto>>(result.Data);   
        }
    }
}