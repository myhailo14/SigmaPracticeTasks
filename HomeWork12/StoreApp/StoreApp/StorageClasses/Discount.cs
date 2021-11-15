using StoreApp.UserClasses;

namespace StoreApp.StorageClasses;

class Discount
{
    private List<Product> _product;
    private double _discount;
    private bool _forPremium;
    private bool _forCommon;
    private bool _forNew;

    public Discount(List<Product> product, double discount, bool forPremium, bool forCommon, bool forNew)
    {
        _product = product;
        _discount = discount;
        _forPremium = forPremium;
        _forCommon = forCommon;
        _forNew = forNew;
    }
}