using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BartenderApp.Models
{
    public class Orders
    {
        [Key]
        public string ItemId { get; set; }
        public string CustomerName { get; set; }
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public virtual Cocktails Cocktails { get; set; }
    }
}
