using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public decimal TotalPriceWithVat { get; set; }
    }
}
