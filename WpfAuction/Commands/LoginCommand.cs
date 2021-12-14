using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.ViewModels;

namespace WpfAuction.Commands
{
    internal class LoginCommand : ICommand
    {
        private LoginViewModel _logInViewModel;
        
        private bool LogSuccesfully;

        public LoginCommand(LoginViewModel logInViewModel)
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
           
            LogSuccesfully = this._logInViewModel.UserLogic.Login(this._logInViewModel.LoginName, this._logInViewModel.Password);
            if (LogSuccesfully == true)
            {
                this._logInViewModel.IsLoggedIn = false;
                this._logInViewModel.LoginViewButtonContent = "Log out";
                if (LogSuccesfully == true)
                {
                    this._logInViewModel.MainViewModel.Role = "Admin";

                }
                
                
                this._logInViewModel.LoginButtonCommand = new LogOutCommand(this._logInViewModel);
            }
            else
            {
                this._logInViewModel.ErrorLogin();
            }

        }
    }
}
