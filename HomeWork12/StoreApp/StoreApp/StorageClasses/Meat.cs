using StoreApp.Enums;

namespace StoreApp.StorageClasses;

class Meat : Product
{
    private MeatType _meatType;
    private MeatSort _meatSort;

    public Meat()
    {
        _meatSort = MeatSort.Mutton;
        _meatType = MeatType.First;
    }

    public Meat(MeatType meatType, MeatSort meatSort, string name, double price, double weight, int expirationTerm, DateOnly madeDate) :
        base(name, price, weight, expirationTerm, madeDate)
    {
        _meatType = meatType;
        _meatSort = meatSort;
    }
}