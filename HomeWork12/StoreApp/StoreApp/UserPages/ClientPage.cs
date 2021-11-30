using StoreApp.Mediators;

namespace StoreApp.UserPages;

class ClientPage : IPage
{
    private IMediator _clientMediator;
    private Func<string> _inputInstance;
    private Action<string> _outputInstance;
    private Action _clearAction;

    public ClientPage(IMediator clientMediator, Func<string> inputInstance, Action<string> outputInstance, Action clearAction)
    {
        ExceptionHandler.CheckIfNull(clientMediator);
        ExceptionHandler.CheckIfNull(inputInstance);
        ExceptionHandler.CheckIfNull(outputInstance);
        ExceptionHandler.CheckIfNull(clearAction);

        _clientMediator = clientMediator;
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
            _clientMediator.ShowActions();
            int actionId = -1;
            while (true)
            {
                if (int.TryParse(_inputInstance(), out actionId) && actionId is > 0 and < 7)
                {
                    break;
                }

                if (_clientMediator.CheckAction(actionId))
                {
                    break;
                }
            }

            _clientMediator.SendMessage(actionId, out var isExit, out nextPage);
            if (isExit == true)
            {
                break;
            }
        }

        return nextPage;
    }
}