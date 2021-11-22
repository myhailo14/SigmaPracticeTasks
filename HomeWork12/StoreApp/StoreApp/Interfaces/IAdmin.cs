using StoreApp.Enums;
using StoreApp.StorageClasses;
using StoreApp.UserClasses;

namespace StoreApp.Interfaces;

interface IAdmin
{
    bool SetClientStatus(Client client, Status status);
}