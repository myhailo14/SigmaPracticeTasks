using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Mediators;

namespace StoreApp.UserPages
{
    class LoginPage : IPage
    {
        private IMediator _userMediator;
        private Func<string> _inputInstance;
        private Action<string> _outputInstance;
        private Action _clearAction;

        public LoginPage(IMediator userMediator, Func<string> inputInstance, Action<string> outputInstance, Action clearAction)
        {
            ExceptionHandler.CheckIfNull(userMediator);
            ExceptionHandler.CheckIfNull(inputInstance);
            ExceptionHandler.CheckIfNull(outputInstance);
            ExceptionHandler.CheckIfNull(clearAction);

            _userMediator = userMediator;
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
                _userMediator.ShowActions();
                int actionId = -1;
                while (true)
                {
                    if (int.TryParse(_inputInstance(), out actionId) && actionId is > 0 and < 7)
                    {
                        break;
                    }

                    if (_userMediator.CheckAction(actionId))
                    {
                        break;
                    }
                }

                _userMediator.SendMessage(actionId, out var isExit, out nextPage);
                if (isExit == true)
                {
                    break;
                }
            }

            return nextPage;
        }
    }
}
