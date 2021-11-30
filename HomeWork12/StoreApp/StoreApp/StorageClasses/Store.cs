using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using StoreApp.Enums;
using StoreApp.UserClasses;

namespace StoreApp.StorageClasses;

class Store
{
    private static readonly Lazy<Store> Lazy = new Lazy<Store>(() => new Store());
    public static Store Instance => Lazy.Value;


    private List<Admin> _adminList;
    private List<Moderator> _moderatorList;
    private ClientBase _clientBase;
    private List<Discount> _discountList;

    private Storage _storage;

    private Store()
    {
        _adminList = new List<Admin>();
        _moderatorList = new List<Moderator>();
        _discountList = new List<Discount>();
        _storage = new Storage();
        _clientBase = new ClientBase();
        Moderator moderator = new Moderator();
        _moderatorList.Add(moderator);
        Admin admin = new Admin();
        _adminList.Add(admin);
        Client client = new Client();
        _clientBase.AddClient(client);
    }


    //user list operations
    public User? FindUser(User sender, string email)
    {
        return sender is not Admin ? null : _clientBase.GetClient(email);
    }
    //discounts operations
    public void AddDiscount(Discount discount)
    {
        _discountList.Add(discount);
    }
    public bool RemoveDiscount(Discount discount)
    {
        return _discountList.Remove(discount);
    }

    //user operations
    public void RegisterNewUser(User newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser));
        }

        if (newUser.GetType() == typeof(Client))
        {
            _clientBase.AddClient(newUser as Client);
            return;
        }

        if (newUser.GetType() == typeof(Admin))
        {
            _adminList.Add(newUser as Admin);
            return;
        }

        if (newUser.GetType() != typeof(Moderator)) return;
        _moderatorList.Add(newUser as Moderator);
        return;

    }
    public void RemoveClient(User sender, Client target)
    {
        if (sender.GetType() != typeof(Moderator))
        {
            return;
        }

        _clientBase.RemoveClient(target);
    }

    public void ChangeClientStatus(User client, Status status)
    {
        if (client.GetType() != typeof(Client)) return;
        _clientBase.ChangeStatus(client as Client, status);
    }

    public bool Login(User? sender, string login, string password)
    {
        if (_clientBase.GetClient(login) != null
            || _adminList.Find(x => x.Login == login) != null
            || _moderatorList.Find(x => x.Login == login) != null)
        {
            return true;
        }
        return false;
    }

    // storage operations
    public Storage GetProductList()
    {
        return _storage;
    }
    public void AddProduct(User sender, Product product)
    {
        if (sender == null)
        {
            throw new ArgumentNullException(nameof(sender));
        }

        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (!_adminList.Contains(sender)) return;
        Instance._storage.AddProduct(product);

    }
    public void RemoveProduct(User sender, Product product)
    {
        if (sender == null)
        {
            throw new ArgumentNullException(nameof(sender));
        }

        if (sender.GetType() != typeof(Admin) && !_adminList.Contains(sender))
        {
            return;
        }

        if (sender.GetType() != typeof(Moderator) && !_moderatorList.Contains(sender))
        {
            return;
        }

        _storage.RemoveProduct(product);
    }
    public void RemoveExpiredProducts()
    {

    }

}