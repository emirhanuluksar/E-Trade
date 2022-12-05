using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccess.EntityFramework;
using Domain.Entities.Concrete;
using Persistence.Abstract;

namespace Persistence.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ETradeContext>, ICustomerDal
    {
        public List<OperationClaim> GetClaims(Customer customer)
        {
            using (var context = new ETradeContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join customerOperationClaim in context.CustomerOperationClaims
                                 on operationClaim.Id equals customerOperationClaim.OperationClaimId
                             where customerOperationClaim.CustomerId == customer.CustomerId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}