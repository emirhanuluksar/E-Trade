using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Application.Utilities.Security.JWT;
using Domain.Entities.Concrete;

namespace Infrastructure.Abstract
{
    public interface IAuthService
    {
        IDataResult<Customer> Register(CustomerForRegisterDto customerForRegisterDto,string password);
        IDataResult<Customer> Login(CustomerForLoginDto customerForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Customer customer);
    }
}