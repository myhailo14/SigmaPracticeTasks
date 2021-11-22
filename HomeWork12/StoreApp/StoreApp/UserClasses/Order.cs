using System.Text;
using StoreApp.Interfaces;
using StoreApp.StorageClasses;

namespace StoreApp.UserClasses;

class Basket : IProductHandler
{
    private List<Product> _products;
    public bool AddProduct(Product product)
    {
        _products.Add(product);
        return true;
    }

    public bool AddProducts(List<Product> products)
    {
        _products.AddRange(products);
        return true;
    }

    public bool RemoveProduct(Product product)
    {
        _products.Remove(product);
        return true;
    }

    public bool RemoveProduct(List<Product> products)
    {
        foreach (var product in products)
        {
            _products.Remove(product);
        }

        return true;
    }


    public bool RemoveProduct(string name)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        if (_products == null || _products.Count == 0)
        {
            return "Your basket is empty";
        }
        var sb = new StringBuilder();
        foreach (var product in _products)
        {
            sb.Append(product.ToString() + "\n");
        }
        return sb.ToString();
    }
}
class Order
{
    private long _id;
    private Basket _basket;
    private bool _needDelivery;
    private string _address;
    private double _totalCost;

    void ConfirmOrder()
    {

    }
}