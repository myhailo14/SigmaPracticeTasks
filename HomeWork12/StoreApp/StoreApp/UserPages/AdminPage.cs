using System.Runtime.InteropServices;
using StoreApp.Mediators;

namespace StoreApp.UserPages;

class ExceptionHandler
{
    public static void CheckIfNull(object obj)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
    }
}

class AdminPage : IPage
{
    private IMediator _adminMediator;
    private Func<string> _inputInstance;
    private Action<string> _outputInstance;
    private Action _clearAction;

    public AdminPage(IMediator adminMediator, Func<string> inputInstance, Action<string> outputInstance, Action clearAction)
    {
        ExceptionHandler.CheckIfNull(adminMediator);
        ExceptionHandler.CheckIfNull(inputInstance);
        ExceptionHandler.CheckIfNull(outputInstance);
        ExceptionHandler.CheckIfNull(clearAction);

        _adminMediator = adminMediator;
        _inputInstance = inputInstance;
        _outputInstance = outputInstance;
        _clearAction = clearAction;
    }

    public IPage? Load()
    {
        IPage? nextPage = null;
        while (true)
        {
            _clearAction();
            _outputInstance("What you want to do?");
            _adminMediator.ShowActions();
            int actionId = -1;
            while (true)
            {
                if (int.TryParse(_inputInstance(), out actionId) && actionId is > 0 and < 7)
                {
                    break;
                }

                if (_adminMediator.CheckAction(actionId))
                {
                    break;
                }
            }

            _adminMediator.SendMessage(actionId, out var isExit, out nextPage);
            if (isExit == true)
            {
                break;
            }
        }

        return nextPage;
    }


}