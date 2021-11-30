using StoreApp.Enums;
using StoreApp.StorageClasses;
using StoreApp.UserClasses;
using StoreApp.UserPages;

namespace StoreApp.Mediators;

interface IMediator
{
    void SendMessage(int requestId, out bool isExit, out IPage? nextPage);
    void ShowActions();
    bool CheckAction(int requestId);
}


class AdminMediator : IMediator
{
    private Admin _admin;
    private Func<string> _inputInstance;
    private Action<string> _outputInstance;
    private Action _clearOutput;
    public AdminMediator(Admin admin, Func<string> inputInstance, Action<string> outputInstance, Action clearOutput)
    {
        _admin = admin;
        _inputInstance = inputInstance;
        _outputInstance = outputInstance;
        _clearOutput = clearOutput;
    }

    public void SendMessage(int requestId, out bool isExit, out IPage? nextPage)
    {
        isExit = false;
        nextPage = null;
        if (!CheckAction(requestId))
        {
            return;
        }

        switch (requestId)
        {
            case 1:
                SendStatusChangeAction();
                return;
            case 2:
                SendClientRemoveAction();
                return;
            case 3:
                SendAddProductAction();
                return;
            case 4:
                SendRemoveAction();
                return;
            case 5:
                SendRemoveExpiredAction();
                return;
            case 6:
                SendPasswordChangeAction();
                return;
        }

        IPage next = new WelcomePage();

    }

    public void ShowActions()
    {
        _outputInstance("1. Set client status\n");
        _outputInstance("2. Ban client\n");
        _outputInstance("3. Add product to storage\n");
        _outputInstance("4. Remove product from storage\n");
        _outputInstance("5. Remove expired products\n");
        _outputInstance("6. Change password\n");
        _outputInstance("7. Log out\n");
    }

    public bool CheckAction(int requestId)
    {
        return requestId is > 0 and < 7;
    }

    public void SendStatusChangeAction()
    {
        _outputInstance("Enter client's email");
        string email = _inputInstance();  // ADD PATTERN CHECK LATER
        _outputInstance("Enter number of status");
        _outputInstance(" 1. Common");
        _outputInstance(" 2. Premium");
        var newStatus = (Status)int.Parse(_inputInstance());
        var instance = Store.Instance;
        if (instance.FindUser(_admin, email) == null)
            _outputInstance("There is no user with this email");
        else
            instance.ChangeClientStatus(instance.FindUser(_admin, email), newStatus);
    }

    public void SendClientRemoveAction()
    {

    }

    public void SendAddProductAction()
    {

    }

    public void SendRemoveAction()
    {

    }

    public void SendRemoveExpiredAction()
    {

    }

    public void SendPasswordChangeAction()
    {

    }

    private void WaitForKey()
    {

    }

}

class ModeratorMediator
{

}

class ClientMediator
{
    private Client _client;
    private Func<string> _inputInstance;
    private Action<string> _outputInstance;
    private Action _clearOutput;
    public ClientMediator(Client client, Func<string> inputInstance, Action<string> outputInstance, Action clearOutput)
    {
        _client = client;
        _inputInstance = inputInstance;
        _outputInstance = outputInstance;
        _clearOutput = clearOutput;
    }

    public void SendMessage(int requestId, out bool isExit, out IPage? nextPage)
    {
        isExit = false;
        nextPage = null;
        if (!CheckAction(requestId))
        {
            return;
        }

        switch (requestId)
        {
            case 1:
              return;
        }

        IPage next = new WelcomePage();

    }

    public void ShowActions()
    {
        _outputInstance("1. See assortment\n");
        _outputInstance("2. See basket\n");
        _outputInstance("3. Create order from basket\n");
        _outputInstance("4. Clear basket\n");
        _outputInstance("5. Change password\n");
        _outputInstance("6. Log out\n");
    }

    public bool CheckAction(int requestId)
    {
        return requestId is > 0 and < 7;
    }

    public void SendAssortmentRequest()
    {
        _outputInstance("Assortment:");
        _outputInstance(Store.Instance.GetProductList().ToString());
    }

    public void SendBasketRequest()
    {
        _outputInstance("Your basket:");
        _outputInstance(_client.SeeBasket());
    }

}

class StoreMediator
{
    private Store _store;
    private Func<string> _inputInstance;
    private Action<string> _outputInstance;
    private Action _clearOutput;
    public StoreMediator(Store store, Func<string> inputInstance, Action<string> outputInstance, Action clearOutput)
    {
        _store = store;
        _inputInstance = inputInstance;
        _outputInstance = outputInstance;
        _clearOutput = clearOutput;
    }

    public bool CheckAction(int requestId)
    {
        return requestId is > 0 and < 6;
    }

    public void SendMessage(int requestId, out bool isExit)
    {
        isExit = false;
        if (!CheckAction(requestId))
        {
            return;
        }

        switch (requestId)
        {
            case 1:
                SendRegisterAction();
                return;
            case 2:
                SendLoginClient();
                return;
            case 3:
                SendLoginAdmin();
                return;
            case 4:
                SendLoginModerator();
                return;
        }

        isExit = true;

    }

    public void ShowActions()
    {
        _outputInstance("1. Register\n");
        _outputInstance("2. _login as client\n");
        _outputInstance("3. _login as client\n");
        _outputInstance("4. _login as moderator\n");
        _outputInstance("5. Exit\n");
    }

    public void SendRegisterAction()
    {
        _outputInstance("Registering new user:");
        _outputInstance(" Enter name: ");
        _outputInstance(" Enter surname: ");
        _outputInstance(" Enter phone number:");
        _outputInstance(" Enter e-mail:");
        _outputInstance(" Enter birth date:");
        _outputInstance(" Enter login:");
        _outputInstance(" Enter password:");
        _outputInstance("");
        _outputInstance("");

    }

    public void SendLoginClient()
    {

    }

    public void SendLoginAdmin()
    {

    }

    public void SendLoginModerator()
    {

    }

}