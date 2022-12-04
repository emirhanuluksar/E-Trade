using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Concrete.EntityFramework
{
    public class ETradeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=yourdb;Trusted_Connection=true");
        }

        public DbSet<Customer> Customers {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Store> Stores {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
    }
}
