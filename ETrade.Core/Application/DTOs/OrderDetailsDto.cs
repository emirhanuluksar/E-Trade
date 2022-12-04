using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Application.DTOs
{
    public class OrderDetailsDto : IDto
    {
        public int OrderId {get; set;}
        public string StoreName {get; set;}
        public string CategoryName {get; set;}
        public string ProductName {get; set;}                                                                  
        public string CustomerName {get; set;}
        public string CustomerAddress {get; set;}
        public DateTime OrderDate {get; set;}
        
    }
}