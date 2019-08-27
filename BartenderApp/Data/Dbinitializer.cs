using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BartenderApp.Models;

namespace BartenderApp.Data
{
    public class Dbinitializer
    {
        public static void Initialize(BartenderAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cocktails.Any())
            {
                return;
            }

            var cocktails = new Cocktails[]
            {
                new Cocktails{CocktailName = "Long Island", CocktailPrice = 15.99},
                new Cocktails { CocktailName = "Jack and Coke", CocktailPrice = 8.99 }
            };
            foreach (Cocktails c in cocktails){
                context.Cocktails.Add(c);
            }
            context.SaveChanges();

            var orders = new Orders[]
            {
                new Orders{CustomerName = "Jenny" },
                new Orders{CustomerName ="Alfred" }
            };
            foreach (Orders o in orders)
            {
                context.Orders.Add(o);
            }
            context.SaveChanges();
        }
    }
}
