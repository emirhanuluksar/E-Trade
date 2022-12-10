using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Address : IEntity
    {
        public int AddressId {get; set;}
        public string DeliveryAddress {get; set;}
        public int CountryId {get; set;}
    }
}