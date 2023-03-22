using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Repository.IRepository
{
    public interface IVatCalculator
    {
        ProductViewModel CalculateTotalPriceWithVAT(Product product);
        IEnumerable<ProductViewModel> CalculateTotalPriceWithVAT(IEnumerable<Product> products);
    }
}
