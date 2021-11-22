using StoreApp.UserClasses;

namespace StoreApp.Interfaces;

interface IModerator
{

    bool InspectOrder(Order order);
    bool DeleteOrder(Order order);

}