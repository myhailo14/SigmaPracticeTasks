using System.Text;
using StoreApp.Enums;
using StoreApp.Interfaces;
using StoreApp.StorageClasses;

namespace StoreApp.UserClasses;

class Client : User, IClient
{
    public Status Status { get; set; }
    public Basket Basket;
    public List<Product> SeeProductsList()
    {
        throw new NotImplementedException();
    }

    public bool CreateOrder()
    {
        throw new NotImplementedException();
    }

    public bool MakePurchase()
    {
        throw new NotImplementedException();
    }

    public string SeeBasket()
    {
        return Basket.ToString();

    }
}