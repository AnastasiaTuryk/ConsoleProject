using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.ViewModels;

namespace WpfAuction.Commands
{
    public class CreateAuctionCommand : ICommand
    {
        private MainViewModel _mainViewModel;
        private GoodsViewModel _productViewModel;

        public CreateAuctionCommand(GoodsViewModel productViewModel, MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
            this._productViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._productViewModel.ButtonCreateIsEnable;
        }

        public void Execute(object parameter)
        {
            this._mainViewModel.LogicAuction.AddAuction(
                this._productViewModel.SelectedItem.Item1.Id,
                
                Convert.ToInt32(this._productViewModel.AuctionStartPrice),
                Convert.ToInt32(this._productViewModel.AuctionEndPrice),
                Convert.ToDateTime(this._productViewModel.AuctionEndTime));
            this._productViewModel.AuctionStartPrice = "";
            this._productViewModel.AuctionEndPrice = "";
            this._productViewModel.AuctionEndTime = "";
        }
    }
}
