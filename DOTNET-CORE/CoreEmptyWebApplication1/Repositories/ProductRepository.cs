using CoreEmptyWebApplication1.Interfaces;
using CoreEmptyWebApplication1.Models;

namespace CoreEmptyWebApplication1.Repositories
{
    public class ProductRepository : IProductInterface
    {
        private List<ProductModel> products = new List<ProductModel>();


        public int AddProduct(ProductModel product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return product.Id;
        }

        public List<ProductModel> GetAll()
        {
            return products;
        }
    }
}
