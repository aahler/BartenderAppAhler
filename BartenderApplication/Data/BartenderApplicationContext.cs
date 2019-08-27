using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BartenderApplication.Models;

namespace BartenderApplication.Models
{
    public class BartenderApplicationContext : DbContext
    {
        public BartenderApplicationContext (DbContextOptions<BartenderApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<BartenderApplication.Models.Product> Product { get; set; }

        public DbSet<BartenderApplication.Models.Order> Order { get; set; }
        
    }
}
