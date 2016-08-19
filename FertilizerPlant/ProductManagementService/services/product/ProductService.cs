using ProductManagementService.entities.produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.services
{
    public interface ProductService
    {
        IList<ProductModel> GetAll();
        IList<string> GetAllProductNames();
        void Add(ProductModel product);

        ProductModel FindByProductName(string productName);
    }
}
