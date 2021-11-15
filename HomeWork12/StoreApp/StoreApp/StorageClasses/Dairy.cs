namespace StoreApp.StorageClasses;

class Dairy : Product
{
    public Dairy() : base()
    {

    }

    public Dairy(string name, double price, double weight, int expirationTerm, DateOnly madeDate) :
        base(name, price, weight, expirationTerm, madeDate)
    {

    }
}