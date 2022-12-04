using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public string Address {get; set;}
        public DateTime SignDate {get; set;}
    }
}