using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class City : IEntity
    { 
        public int CityId {get; set;}
        public string CityName {get; set;}
        public int RegionId {get; set;}
    }
}