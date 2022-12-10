using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Country : IEntity
    {
        public int CountryId {get; set;}
        public string CountryName {get; set;}
        public int CityId {get; set;}
    }
}