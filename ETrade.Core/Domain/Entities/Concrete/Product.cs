using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId {get; set;}
        public int CategoryId {get; set;}
        public int StoreId {get; set;}
        public string ProductName {get; set;}
        public int UnitsInStock {get; set;}
        public decimal UnitPrice {get; set;}
        public int UnitsOnOrder {get; set;}
        public string Barcode {get; set;}
        public int Evaluate {get; set;}
        

    }
}