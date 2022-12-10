using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId {get; set;}
        public int CustomerId {get; set;}
        public int ProductId {get; set;}
        public DateTime OrderDate {get; set;}
        public DateTime EstimatedDeliveryDate {get; set;}
        public DateTime DeliveryDate {get; set;}
    }
}