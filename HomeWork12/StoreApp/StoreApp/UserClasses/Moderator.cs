using StoreApp.Interfaces;
using StoreApp.StorageClasses;

namespace StoreApp.UserClasses;

class Moderator : User, IModerator, IDiscount
{
    public Moderator() : base()
    {
        _login = "testModerator1";
    }

    public Moderator(long id, string name, string surname, string phoneNumber, DateOnly birthDate, string login, string password) :
        base(id, name, surname, phoneNumber, birthDate, login, password)
    {

    }
    public bool InspectOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public bool DeleteOrder(Order order)
    {
        var storeInstance = Store.Instance;

        throw new NotImplementedException();
    }

    public bool CreateDiscount(Product product, bool forAll)
    {
        throw new NotImplementedException();
    }

    public bool CreateDiscount(List<Product> products, bool forAll)
    {
        throw new NotImplementedException();
    }
}