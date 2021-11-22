using StoreApp.Enums;
using StoreApp.UserClasses;

namespace StoreApp.StorageClasses;

interface IClientBase
{
    bool AddClient(Client client);
    bool RemoveClient(Client client);
    List<Client> GetPremiums();
    List<Client> GetCommons();
}

class ClientBase : IClientBase
{
    private List<Client> _clientList = new List<Client>();

    public Client? GetClient(string email)
    {
       return _clientList.Find(c => c.Email.Equals(email));
    }

    public Client? GetClient(Client client)
    {
        return _clientList.Find(x => x == client);
    }

    public bool AddClient(Client client)
    {
        _clientList.Add(client);
        return true;
    }

    public bool RemoveClient(Client client)
    {
        _clientList.Remove(client);
        return true;
    }

    public void ChangeStatus(Client client, Status status)
    {
        if (!ClientExists(client))
        {
            return;
        }

        client.Status = status;
    }

    private bool ClientExists(Client client)
    {
        return _clientList.Contains(client);
    }

    public List<Client> GetPremiums() => _clientList.FindAll(item => item.Status is Status.Premium);
    public List<Client> GetCommons() => _clientList.FindAll(item => item.Status is Status.Common);
}