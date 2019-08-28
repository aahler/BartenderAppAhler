using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartenderApplication.Models
{
    public class ProductModel
    {
       
        private List<Product> products;

        public ProductModel()
        {
            this.products = new List<Product>() {
                new Product {
                    Id = "1",
                    Name = "Jack and Coke",
                    Price = 5.25,
                    Photo = "Jack_n_Coke.jpg"
                },
                new Product {
                    Id = "2",
                    Name = "Long Island",
                    Price = 12.55,
                    Photo = "Long_Island.jpg"
                },
                new Product {
                    Id = "3",
                    Name = "Margarita",
                    Price = 6.75,
                    Photo = "Margarita.jpg"
                }
            };
        }

        public List<Product> findAll()
        {
            return this.products;
        }

        public Product find(string id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }

    }
}
