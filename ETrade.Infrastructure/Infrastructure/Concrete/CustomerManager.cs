using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aspects.Autofac.Validation;
using Application.DTOs;
using Application.Utilities.Business;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using Infrastructure.ValidationRules.FluentValidation;
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

        [ValidationAspect(typeof(CustomerValidator))]
        public void Add(Customer customer)
        {
            var result = BusinessRules.Run();
            _customerDal.Add(customer);
        }

        // Validation
        // PerformanceAspect
        // SecuredOperation
        // Caching
        public IResult BuyProduct(Product product, int customerId, int piece)
        {
                //_productService.Remove(product,piece);
            var result2 = _orderService.CreateOrder(customerId,product,piece);
            if(result2.Success)
            {
                return new SuccessResult(Messages.OrderCreated);
            }
            return new ErrorResult();   
        }

        public Customer GetByMail(string email)
        {
            var result = _customerDal.Get(u => u.Email == email);
            if(result != null)
            {
                return result;
            }
            return Messages.Deneme;
        }

        public List<OperationClaim> GetClaims(Customer customer)
        {
            var result = _customerDal.GetClaims(customer);
            if(result != null)
            {
                return result;
            }
            return null;
            //return _customerDal.GetClaims(customer);
        }

        public IDataResult<List<OrderDetailsDto>> GetMyOrders(int customerId)
        {
            var result = _orderService.GetCustomerOrders(customerId);
            if(result.Success)
            {
                return new SuccessDataResult<List<OrderDetailsDto>>(result.Data);
            }
            return new ErrorDataResult<List<OrderDetailsDto>>();
            // var result = _orderService.GetCustomerOrders(customerId);
            // return new SuccessDataResult<List<OrderDetailsDto>>(result.Data);   
        }








    }
}