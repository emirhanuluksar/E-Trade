using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Store : IEntity
    {
        public int StoreId {get; set;}
        public string StoreName {get; set;}
        public int AddressId {get; set;}
        public DateTime CreatedDate {get; set;}
        public int NumberOfProduct {get; set;}
        public DateTime DeliveryTimeToCargo {get; set;}
        public int AnswerRate {get; set;}
        public int Rating {get; set;}
    }

}