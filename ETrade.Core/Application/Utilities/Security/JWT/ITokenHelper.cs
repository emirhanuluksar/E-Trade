using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Concrete;

namespace Application.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Customer customer, List<OperationClaim> operationClaims);
    }
}