using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(int id,  Product newProduct);
        Product GetProduct(Func<Product, bool>? predicate = null);
        List<Product> GetAllProducts(Func<Product, bool>? predicate = null); 

    }
}
