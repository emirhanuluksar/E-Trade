using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class CustomerOperationClaim : IEntity
    {
        public int Id {get; set;}
        public int CustomerId {get; set;}
        public int OperationClaimId {get; set;}
    }
}