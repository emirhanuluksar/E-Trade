using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccess;
using Domain.Entities.Concrete;

namespace Persistence.Abstract
{
    public interface ICustomerOperationClaimDal : IEntityRepository<CustomerOperationClaim>
    {
        
    }
}