using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Application.DTOs
{
    public class CustomerForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}