using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BartenderApp.Models
{
    public class BartenderAppContext : DbContext
    {
        public BartenderAppContext()
        {
        }

        public BartenderAppContext (DbContextOptions<BartenderAppContext> options)
            : base(options)
        {
        }

        public DbSet<BartenderApp.Models.Cocktails> Cocktails { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
