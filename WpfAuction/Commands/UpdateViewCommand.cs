using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.ViewModels;

namespace WpfAuction.Commands
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_mainViewModel.Role == "Admin")
            {
                
                if (parameter.ToString() == "Goods")
                {
                    this._mainViewModel.SelectedViewModel = new GoodsViewModel(this._mainViewModel.LogicGoods, this._mainViewModel);
                }
                else if (parameter.ToString() == "Auctions")
                {
                    this._mainViewModel.SelectedViewModel = new AuctionViewModel(this._mainViewModel.LogicGoods, this._mainViewModel.LogicAuction, this._mainViewModel);
                }
            }
            
        }
    }
}
