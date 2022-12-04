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
        public int StoreId {get; set;}
        public int CategoryId {get; set;}
        public int ProductId {get; set;}
        public int CustomerId {get; set;}
        public DateTime OrderDate {get; set;}
    }
}