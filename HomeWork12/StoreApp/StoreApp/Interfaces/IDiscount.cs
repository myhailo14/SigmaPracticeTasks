using StoreApp.StorageClasses;

namespace StoreApp.Interfaces;

interface IDiscount
{
    bool CreateDiscount(Product product, bool forAll);
    bool CreateDiscount(List<Product> products, bool forAll);

}