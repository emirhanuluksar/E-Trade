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
    }
}