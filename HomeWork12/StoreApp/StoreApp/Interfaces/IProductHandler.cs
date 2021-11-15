using StoreApp.StorageClasses;
using StoreApp.UserClasses;

namespace StoreApp.Interfaces;

public interface IProductHandler
{
    bool AddProduct(Product product);
    bool AddProducts(List<Product> products);
    bool RemoveProduct(Product product);
    bool RemoveProduct(List<Product> products);
    StorageNorms getStorageNorms();
}