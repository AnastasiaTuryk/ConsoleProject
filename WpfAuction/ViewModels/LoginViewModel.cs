using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAuction.Commands;

namespace WpfAuction.ViewModels
{
    internal class LoginViewModel : BaseViewModel, INotifyPropertyChanged, IDataErrorInfo
    {
        #region Private Properties
        private string _uName;
        private string _pass;
        private string _loginViewButtonContent = "Log in";
        private MainViewModel _mainViewModel;
        private BusinessUser logicUser;
        private ICommand _loginButtonCommand;
        private bool _isLoggedIn = true;

        #endregion

        public bool IsLoggedIn
        {
            get => this._isLoggedIn;
            set
            {
                this._isLoggedIn = value;
                OnPropertyChanged("IsLoggedIn");
            }
        }
        public ICommand LoginCommand { get; set; }
        public LoginViewModel(MainViewModel mainViewModel, BusinessUser serviceAuth)
        {
            this._mainViewModel = mainViewModel;
            this.logicUser = serviceAuth;
            this.LoginButtonCommand = new LoginCommand(this);
        }

        public ICommand LoginButtonCommand
        {
            get => this._loginButtonCommand;
            set
            {
                this._loginButtonCommand = value;
                OnPropertyChanged("LoginButtonCommand");
            }
        }
        public string LoginName
        {
            get => this._uName;
            set
            {
                this._uName = value;
                OnPropertyChanged("LoginName");
            }
        }

        public string LoginViewButtonContent
        {
            get => this._loginViewButtonContent;
            set
            {
                this._loginViewButtonContent = value;
                OnPropertyChanged("LoginViewButtonContent");
            }
        }

        public MainViewModel MainViewModel
        {
            get => this._mainViewModel;
        }
        public string Password
        {
            get => this._pass;
            set
            {
                this._pass = value;
                OnPropertyChanged("Password");
            }
        }

        internal void ErrorLogin()
        {
            MessageBox.Show("Wrong login or password", "Error");
        }

        public BusinessUser UserLogic { get => this.logicUser; }

        #region Validation
        private bool _isValidPass;
        private bool _isValidUserName;
        private bool _buttonLogInIsEnable;
        public bool ButtonLogInIsEnable
        {
            get => this._buttonLogInIsEnable;
            set
            {
                this._buttonLogInIsEnable = value;
                OnPropertyChanged("ButtonLogInIsEnable");
            }
        }
        public bool IsValidUserName
        {
            get => this._isValidUserName;
            set
            {
                if (this._isValidUserName != value)
                    this._isValidUserName = value;
            }
        }
        public bool IsValidPass
        {
            get => this._isValidPass;
            set
            {
                if (this._isValidPass != value)
                    this._isValidPass = value;
            }
        }
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "UserPassword":
                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            _result = "Password cannot be empty";
                            IsValidPass = false;
                        }
                        else if (Password.Contains(" "))
                        {
                            _result = "Using space is not allowed";
                            IsValidPass = false;
                        }
                        else
                        {
                            IsValidPass = true;
                        }
                        break;
                    case "UserName":
                        if (string.IsNullOrWhiteSpace(LoginName))
                        {
                            _result = "UserName cannot be empty";
                            IsValidUserName = false;
                        }
                        else if (LoginName.Contains(" "))
                        {
                            _result = "Using space is not allowed";
                            IsValidUserName = false;
                        }
                        else
                        {
                            IsValidUserName = true;
                        }
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = _result;
                else if (_result != null)
                    ErrorCollection.Add(name, _result);
                if (IsValidUserName && IsValidPass)
                    ButtonLogInIsEnable = true;
                else
                    ButtonLogInIsEnable = false;

                OnPropertyChanged("ErrorCollection");
                return _result;
            }
        }

        #endregion

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
