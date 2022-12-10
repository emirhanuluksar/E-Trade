using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Persistence.Abstract;

namespace Infrastructure.Concrete
{
    public class CustomerManager : ICustomerService
    {
        IOrderService _orderService;
        ICustomerDal _customerDal;
        IProductService _productService;

        public CustomerManager(IOrderService orderService, ICustomerDal customerDal, IProductService productService)
        {
            _orderService = orderService;
            _customerDal = customerDal;
            _productService = productService;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        // Validation
        // PerformanceAspect
        // SecuredOperation
        // Caching
        public IResult BuyProduct(Product product, int piece)
        {
            IResult result = _productService.IsThereAProduct(product, piece);
            if(result.Success)
            {
                 
            }
            return new ErrorResult();
        }

        public Customer GetByMail(string email)
        {
            return _customerDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(Customer customer)
        {
            return _customerDal.GetClaims(customer);
        }

        public IDataResult<List<OrderDetailsDto>> GetMyOrders(int customerId)
        {
            var result = _orderService.GetCustomerOrders(customerId);
            return new SuccessDataResult<List<OrderDetailsDto>>(result.Data);   
        }
    }
}