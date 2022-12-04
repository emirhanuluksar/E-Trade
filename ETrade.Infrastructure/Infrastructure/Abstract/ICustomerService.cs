using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities.Concrete;

namespace Infrastructure.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<OrderDetailsDto>> GetMyOrders(int customerId);
    }
}