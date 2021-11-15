using StoreApp.Enums;
using StoreApp.Interfaces;

namespace StoreApp.UserClasses;

class Admin : User, IAdmin
{
    public bool SetClientStatus(Client client, Status status)
    {
        throw new NotImplementedException();
    }
}