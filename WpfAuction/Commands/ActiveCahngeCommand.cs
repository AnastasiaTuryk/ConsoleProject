using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.ViewModels;

namespace WpfAuction.Commands
{
    internal class ActiveCahngeCommand : ICommand
    {
        private AuctionViewModel _auctionViewModel;
        private MainViewModel _mainViewModel;
        public ActiveCahngeCommand(AuctionViewModel auctionViewModel, MainViewModel mainViewModel)
        {
            this._auctionViewModel = auctionViewModel;
            this._mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this._auctionViewModel.SelectedAuction.Active == true)
            {
                this._auctionViewModel.AuctionLogic.DeactiveAuction(this._auctionViewModel.SelectedAuction.Id);
                this._auctionViewModel.Auctions.Clear();
                foreach (Auction auction in this._auctionViewModel.AuctionLogic.GetAllAuctions())
                {
                    this._auctionViewModel.Auctions.Add(auction);
                }
            }
            else if (this._auctionViewModel.SelectedAuction.Active == false)
            {
                this._auctionViewModel.AuctionLogic.ActivateAuction(this._auctionViewModel.SelectedAuction.Id);
                this._auctionViewModel.Auctions.Clear();
                foreach (Auction auction in this._auctionViewModel.AuctionLogic.GetAllAuctions())
                {
                    this._auctionViewModel.Auctions.Add(auction);
                }
            }
        }
    }
}
