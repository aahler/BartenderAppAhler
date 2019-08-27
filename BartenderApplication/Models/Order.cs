using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartenderApplication.Models
{
    public class Order
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int ProductID { get; set; }
    }
}
