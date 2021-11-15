using StoreApp.StorageClasses;
using StoreApp.UserClasses;

namespace StoreApp.Interfaces;

interface IModerator
{
    bool CreateDiscount(Product product, bool forAll);
    bool CreateDiscount(List<Product> products, bool forAll);

    bool InspectOrder(Order order);
    bool DeleteOrder(Order order);

}