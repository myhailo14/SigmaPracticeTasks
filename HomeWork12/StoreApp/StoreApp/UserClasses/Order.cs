using StoreApp.Interfaces;
using StoreApp.StorageClasses;

namespace StoreApp.UserClasses;

class Basket : IProductHandler
{
    private List<Product> _products;
    public bool AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public bool AddProducts(List<Product> products)
    {
        throw new NotImplementedException();
    }

    public bool RemoveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public bool RemoveProduct(List<Product> products)
    {
        throw new NotImplementedException();
    }

    public StorageNorms getStorageNorms()
    {
        throw new NotImplementedException();
    }

    public bool RemoveProduct(string name)
    {
        throw new NotImplementedException();
    }
}
class Order
{
    private long _id;
    private Basket _basket;
    private bool _needDelivery;
    private string _address;
    private double _totalCost;
}