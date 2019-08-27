using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BartenderApplication.Models;
using BartenderApplication.Data;

namespace BartenderApplication.Models
{
    public class BartenderApplicationContext : DbContext
    {
        public BartenderApplicationContext ()
            : base()
        {
           
        }

        public DbSet<BartenderApplication.Models.Drink> Drink { get; set; }

        public DbSet<BartenderApplication.Models.Order> Order { get; set; }
    }
}
