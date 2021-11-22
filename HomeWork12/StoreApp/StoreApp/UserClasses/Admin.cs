using StoreApp.Enums;
using StoreApp.Interfaces;
using StoreApp.StorageClasses;

namespace StoreApp.UserClasses;

class Admin : User, IAdmin, IProductHandler
{
    public Admin() : base()
    {
        _login = "testAdmin1";
    }

    public Admin(long id, string name, string surname, string phoneNumber, DateOnly birthDate, string login,
        string password) :
        base(id, name, surname, phoneNumber, birthDate, login, password)
    {

    }

    public bool SetClientStatus(Client client, Status status)
    {
        Store.Instance.Get
        Store.Instance.ChangeClientStatus(client, status);
        return true;
    }

    public bool AddProduct(Product product)
    {
        Store.Instance.AddProduct(this, product);
        return true;
    }

    public bool AddProducts(List<Product> products)
    {
        throw new NotImplementedException();
    }

    public bool RemoveProduct(Product product)
    {
        Store.Instance.RemoveProduct(this, product);
        return true;
    }

    public bool RemoveProduct(List<Product> products)
    {
        throw new NotImplementedException();
    }
}