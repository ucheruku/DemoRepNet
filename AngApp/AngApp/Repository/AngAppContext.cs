using AngApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AngApp.Repository
{
    public class AngAppContext : DbContext
    {
        public AngAppContext(DbContextOptions<AngAppContext> contextOptions):base(contextOptions)
        {
            
        }

            

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        
    }
}