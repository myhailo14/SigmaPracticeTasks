using System.Text;

namespace StoreApp.StorageClasses;

public class Product
{
    protected string _name;
    protected double _price;
    protected double _weight;
    protected int _expirationTerm;
    protected DateOnly _madeDate;

    public string Name => _name;
    public double Price => _price;
    public double Weight => _weight;
    public int ExpirationTerm => _expirationTerm;
    public DateOnly MadeDate => _madeDate;
    public bool IsValid => _madeDate.AddDays(_expirationTerm) > new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

    public Product()
    {
        _name = "Default product";
        _price = 1;
        _weight = 1;
        _expirationTerm = 20;
        _madeDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }
    public Product(string name, double price, double weight, int expirationTerm, DateOnly madeDate)
    {
        _name = name;
        _price = price;
        _weight = weight;
        _expirationTerm = expirationTerm;
        _madeDate = madeDate;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($" Name: {_name}");
        sb.Append($" Price: {_price}");
        sb.Append($" Weight: {_weight}");
        sb.Append($" Expiration: {_expirationTerm}");
        sb.Append($" Made date: {_madeDate}");

        return sb.ToString();
    }
}