using Mark.DataAccess.Repository.IRepository;
using Mark.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark.DataAccess.Repository
{
    public class VatCalculator : IVatCalculator
    {
        public ProductViewModel CalculateTotalPriceWithVAT(Product product)
        {
            decimal totalPriceWithVat = (decimal)(product.Quantity * product.Price) * (1 + ConfigurationVat.ExtraVat);
            return new ProductViewModel { Product = product, TotalPriceWithVat = totalPriceWithVat };
        }

        public IEnumerable<ProductViewModel> CalculateTotalPriceWithVAT(IEnumerable<Product> products)
        {
            return products.Select(p => CalculateTotalPriceWithVAT(p));
        }
    }
}
