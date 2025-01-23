using CoreEmptyWebApplication1.Models;

namespace CoreEmptyWebApplication1.Interfaces
{
    public interface IProductInterface
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetAll();
    }
}
