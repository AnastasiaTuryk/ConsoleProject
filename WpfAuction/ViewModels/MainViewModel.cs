using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLogic;
using WpfAuction.Commands;

namespace WpfAuction.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BusinessGoods logicGoods;
        private BusinessAuction logicAuction;
        private BusinessUser logicUser;
        private BaseViewModel _selectedViewModel;
        private BaseViewModel _selectedAuthViewModel;
        private string _userRole;


        public MainViewModel(BusinessGoods _logicGoods, BusinessUser _logicUser, BusinessAuction _logicAuction)
        {

            this.logicGoods = _logicGoods;
            this.logicUser = _logicUser;
            this.logicAuction = _logicAuction;

            this._selectedAuthViewModel = new LoginViewModel(this, logicUser);
            UpdateViewCommand = new UpdateViewCommand(this);

        }
        public string Role
        {
            get => this._userRole;
            set
            {
                this._userRole = value;
                OnPropertyChanged("Role");
            }
        }
        public BaseViewModel SelectedViewModel
        {
            get => this._selectedViewModel;
            set
            {
                this._selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public BaseViewModel SelectedAuthViewModel
        {
            get => this._selectedAuthViewModel;
            set
            {
                this._selectedAuthViewModel = value;
                OnPropertyChanged(nameof(SelectedAuthViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public BusinessGoods LogicGoods
        {
            get => this.logicGoods;
            set => this.logicGoods = value;
        }
        public BusinessAuction LogicAuction
        {
            get => this.logicAuction;
            set => this.logicAuction = value;
        }
    }
}
