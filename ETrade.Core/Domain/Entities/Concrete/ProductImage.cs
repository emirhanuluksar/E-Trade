using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class ProductImage : IEntity
    {
        public int Id {get; set;}
        public int ProductId {get; set;}
        public string? ImagePath {get; set;}

    }
}