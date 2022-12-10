using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Region : IEntity
    {
        public int RegionId {get; set;}
        public string RegionName {get; set;}
        public string PostalCode {get; set;}
    }
}