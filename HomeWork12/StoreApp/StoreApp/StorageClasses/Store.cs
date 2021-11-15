using StoreApp.UserClasses;

namespace StoreApp.StorageClasses;

class Store
{
    private static readonly Lazy<Store> Lazy = new Lazy<Store>(() => new Store());
    public static Store Instance => Lazy.Value;
    private Store() { }

    private List<Admin> _adminList;
    private List<Moderator> _moderatorList;
    private ClientBase _clientBase;
    private List<Discount> _discountList;

    private Storage _storage;
}