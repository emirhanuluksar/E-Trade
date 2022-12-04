using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Results;

namespace Application.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)   
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}