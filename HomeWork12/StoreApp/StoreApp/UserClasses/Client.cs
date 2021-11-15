using StoreApp.Enums;

namespace StoreApp.UserClasses;

class Client : User
{
    public Status Status { get; private set; }
}