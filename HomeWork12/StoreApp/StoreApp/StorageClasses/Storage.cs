using System.Reflection.Metadata;
using System.Security.Principal;
using StoreApp.Interfaces;
using StoreApp.UserClasses;

namespace StoreApp.StorageClasses;



#region HOMEWORK_13_PART___DECORATOR_TO_ADD_REMOVE

public abstract class ProductHandlerDecorator : IProductHandler
{
    protected IProductHandler ProductHandler;

    protected ProductHandlerDecorator(IProductHandler productHandler)
    {
        ProductHandler = productHandler;
    }

    public abstract bool AddProduct(Product product);
    public abstract bool AddProducts(List<Product> products);
    public abstract bool RemoveProduct(Product product);
    public abstract bool RemoveProduct(List<Product> products);
}

interface ILogger
{
    void LogExpiredProduct(Product product);

}

public class Logger : ILogger
{
    private readonly string _logPath =
        @"C:\Users\mykha\Desktop\Sigma_School\homework\HomeWork12\StoreApp\StoreApp\Files\log.txt";

    public void LogExpiredProduct(Product product)
    {
        using StreamWriter sw = new StreamWriter(_logPath, true);
        sw.WriteLine("Attempt to add/remove expired product");
        sw.WriteLine(DateTime.Now);
        sw.WriteLine("Product info:\n");
        sw.WriteLine(product.ToString());
        sw.WriteLine(new string('-', 100));

    }

    public Logger()
    {

    }

    public Logger(string logPath)
    {
        _logPath = logPath;
    }
}
class AddRemoveWithLog : ProductHandlerDecorator
{
    public AddRemoveWithLog(IProductHandler productHandler) : base(productHandler)
    {

    }

    public override bool AddProduct(Product product)
    {
        ILogger logger = new Logger();
        
        var norms = (ProductHandler as IStorageNorms).GetStorageNorms();
        var typeProd = product.GetType();
        if (product.IsValid == true)
        {
            if (product is Meat)
            {
                if (norms.MeatCurrent + 1 < norms.MeatMax)
                    ProductHandler.AddProduct(product);
                else
                    return false;
            }
            if (product is Dairy)
            {
                if (norms.DairyCurrent + 1 < norms.DairyMax)
                    ProductHandler.AddProduct(product);
                else
                    return false;
            }
            if (product is Product)
            {
                if (norms.ProductCurrent + 1 < norms.ProductMax)
                    ProductHandler.AddProduct(product);
                else
                    return false;
            }

            
        }
        else
        {
            logger.LogExpiredProduct(product);
            return false;
        }

        return true;
    }

    public override bool AddProducts(List<Product> products)
    {
        ILogger logger = new Logger();
        foreach (var product in products)
        {
            AddProduct(product);
        }

        return true;
    }

    public override bool RemoveProduct(Product product)
    {
        ILogger logger = new Logger();
        if (product.IsValid != false) return ProductHandler.RemoveProduct(product);
        logger.LogExpiredProduct(product);
        return false;
    }

    public override bool RemoveProduct(List<Product> products)
    {
        ILogger logger = new Logger();
        foreach (var product in products)
        {
            if (product.IsValid == false)
            {
                logger.LogExpiredProduct(product);
                continue;
            }
            ProductHandler.RemoveProduct(product);
        }

        return true;
    }
}
#endregion

class Storage : IStorageHandler, IProductHandler, IStorageNorms
{
    private StorageNorms _storageNorms = new StorageNorms();
    private List<Product> _productList = new List<Product>();

    public Storage() { }

    public List<Product> RemoveExpired()
    {
        var removedList = _productList.FindAll(item => !item.IsValid);
        foreach (var product in _productList.FindAll(item => item.IsValid == false))
        {
            _productList.Remove(product);
            
        }

        return removedList;
    }

    public List<Product> SearchByName(string name)
    {
        return _productList.FindAll(item => string.Equals(item.Name, name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<Product> SearchByPrice(double lowerPrice, double upperPrice)
    {
        return _productList.FindAll(item => (item.Price >= lowerPrice && item.Price <= upperPrice));
    }

    public List<Product> SearchByWeight(double lowerWeight, double upperWeight)
    {
        return _productList.FindAll(item => item.Weight >= lowerWeight && item.Weight <= upperWeight);
    }

    public List<Product> SearchDairy()
    {
        return _productList.FindAll(item => item is Meat);
    }

    public List<Product> SearchMeat()
    {
        return _productList.FindAll(item => item is Meat);
    }

    public List<Product> GetProductsList()
    {
        return _productList;
    }

    public bool AddProduct(Product product)
    {
        try
        {
            _productList.Add(product);
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public bool AddProducts(List<Product> products)
    {
        try
        {
            _productList.AddRange(products);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool RemoveProduct(Product product)
    {
        return _productList.Remove(product);
    }

    public bool RemoveProduct(List<Product> products)
    {
        try
        {
            return products.Aggregate(false, (current, product) => current || _productList.Remove(product));
        }
        catch (Exception)
        {
            return false;
        }
    }

    public StorageNorms GetStorageNorms()
    {
        return _storageNorms;

    }
}