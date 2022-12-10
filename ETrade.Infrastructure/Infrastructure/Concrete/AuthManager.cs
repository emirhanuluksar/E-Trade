using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Utilities.Results;
using Application.Utilities.Security.Hashing;
using Application.Utilities.Security.JWT;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Infrastructure.Constants;

namespace Infrastructure.Concrete
{
    public class AuthManager : IAuthService
    {
        private ICustomerService _customerService;
        private ITokenHelper _tokenHelper;

        public AuthManager(ICustomerService customerService, ITokenHelper tokenHelper)
        {
            _customerService = customerService;
            _tokenHelper = tokenHelper;

        }

        public IDataResult<Customer> Register(CustomerForRegisterDto customerForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var customer = new Customer
            {
                FirstName = customerForRegisterDto.FirstName,
                LastName = customerForRegisterDto.LastName,
                Email = customerForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AddressId = customerForRegisterDto.AddressId
            };
            _customerService.Add(customer);
            return new SuccessDataResult<Customer>(customer,Messages.CustomerRegistered);
        }

        public IDataResult<Customer> Login(CustomerForLoginDto customerForLoginDto)
        {
            var customerToCheck = _customerService.GetByMail(customerForLoginDto.Email);
            if(customerToCheck == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }

            if(!HashingHelper.VerifyPasswordHash(customerForLoginDto.Password,customerToCheck.PasswordHash,customerToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Customer>(Messages.PasswordError);
            }
            return new SuccessDataResult<Customer>(customerToCheck, Messages.SuccessfulLogin);
        }


        public IResult UserExists(string email)
        {
            if(_customerService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.CustomerAlreadyExists);
            }
            return new SuccessResult();
        }
        public IDataResult<AccessToken> CreateAccessToken(Customer customer)
        {
            var claims = _customerService.GetClaims(customer);
            var accessToken = _tokenHelper.CreateToken(customer, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}