using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Cart : IEntity
    {
        public int CartId {get; set;}
        public int CustomerId {get; set;}
    }
}