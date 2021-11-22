using StoreApp.StorageClasses;

namespace StoreApp.Interfaces;

interface IClient
{
    List<Product> SeeProductsList();
    bool CreateOrder();
    bool MakePurchase();
    string SeeBasket();
}