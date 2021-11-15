using StoreApp.Enums;
using StoreApp.UserClasses;

namespace StoreApp.StorageClasses;

class ClientBase
{
    private List<Client> _clientList;

    public List<Client> GetPremiums() => _clientList.FindAll(item => item.Status is Status.Premium);

    public List<Client> GetCommons() => _clientList.FindAll(item => item.Status is Status.Common);
}