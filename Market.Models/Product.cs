using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }

}
