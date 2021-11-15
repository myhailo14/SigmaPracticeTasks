using StoreApp.StorageClasses;
using StoreApp.UserClasses;

namespace StoreApp.Interfaces;

public interface IStorageHandler
{
    List<Product> RemoveExpired();
    List<Product> SearchByName(string name);
    List<Product> SearchByPrice(double lowerPrice, double upperPrice);
    List<Product> SearchByWeight(double lowerWeight, double upperWeight);
    List<Product> SearchDairy();
    List<Product> SearchMeat();

}