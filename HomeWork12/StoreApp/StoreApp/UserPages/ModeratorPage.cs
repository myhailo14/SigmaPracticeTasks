using StoreApp.Mediators;

namespace StoreApp.UserPages;

class ModeratorPage : IPage
{
    private IMediator _moderatorMediator;
    private Func<string> _inputInstance;
    private Action<string> _outputInstance;
    private Action _clearAction;

    public ModeratorPage(IMediator moderatorMediator, Func<string> inputInstance, Action<string> outputInstance, Action clearAction)
    {
        ExceptionHandler.CheckIfNull(moderatorMediator);
        ExceptionHandler.CheckIfNull(inputInstance);
        ExceptionHandler.CheckIfNull(outputInstance);
        ExceptionHandler.CheckIfNull(clearAction);

        _moderatorMediator = moderatorMediator;
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
            _moderatorMediator.ShowActions();
            int actionId = -1;
            while (true)
            {
                if (int.TryParse(_inputInstance(), out actionId) && actionId is > 0 and < 7)
                {
                    break;
                }

                if (_moderatorMediator.CheckAction(actionId))
                {
                    break;
                }
            }

            _moderatorMediator.SendMessage(actionId, out var isExit, out nextPage);
            if (isExit == true)
            {
                break;
            }
        }

        return nextPage;
    }
}