using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using Persistence.Abstract;

namespace Infrastructure.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IProductService _productService;

        public OrderManager(IOrderDal orderDal, IProductService productService)
        {
            _orderDal = orderDal;
            _productService = productService;
        }

        public IResult CreateOrder(int customerId, Product product, int piece)
        {
            var boolean = _productService.IsThereAProduct(product,piece);
            if(boolean.Success)
            {
                var order = new Order
                {
                    CustomerId = customerId,
                    ProductId = product.ProductId,
                    OrderDate = DateTime.Now,
                    EstimatedDeliveryDate = DateTime.Now,
                    DeliveryDate = DateTime.Now
                };
                var result = _productService.Remove(product,piece);
                if(result.Success)
                {
                    _orderDal.Add(order);
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<List<OrderDetailsDto>> GetCustomerOrders(int customerId)
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDal.GetOrderDetail(customerId));
        }
    }
}