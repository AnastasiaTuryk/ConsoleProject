using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.ViewModels;

namespace WpfAuction.Commands
{
    internal class LogOutCommand : ICommand
    {
        private LoginViewModel _logInViewModel;

        public LogOutCommand(LoginViewModel logInViewModel)
        {
            this._logInViewModel = logInViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            this._logInViewModel.Password = "";
            this._logInViewModel.LoginName = "";
            this._logInViewModel.MainViewModel.Role = "";
            this._logInViewModel.IsLoggedIn = true;
            this._logInViewModel.LoginViewButtonContent = "Log in";
            this._logInViewModel.MainViewModel.SelectedViewModel = null;
            this._logInViewModel.LoginButtonCommand = new LoginCommand(this._logInViewModel);
        }
    }
}
