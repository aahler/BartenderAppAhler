using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartenderApplication.Models
{
    public class ProductContext
    {
        public ProductContext() 
        {        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> ShoppingCartItems { get; set; }

    }
}
