using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BusinessLogic;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.Commands;
using System.Runtime.CompilerServices;

namespace WpfAuction.ViewModels
{
    public class AuctionViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Auction _selectedAuction;
        private ObservableCollection<Auction> _auctions = new ObservableCollection<Auction>();
        private BusinessGoods logicGoods;
        
        private BusinessAuction logicAuction;
        private string _auctionButtonContent;
        private MainViewModel _mainViewModel;
        public BusinessGoods GoodsLogic { get => this.logicGoods; }
        
        public BusinessAuction AuctionLogic { get => this.logicAuction; }
        public Auction SelectedAuction
        {
            get { return this._selectedAuction; }
            set
            {
                this._selectedAuction = value;
                if (this._selectedAuction != null)
                {
                    if (this._selectedAuction.Active == true)
                    {
                        AuctionButtonContent = "Deactivate";
                    }
                    else if (this._selectedAuction.Active == false)
                    {
                        AuctionButtonContent = "Activate";
                    }
                    else
                    {
                        AuctionButtonContent = "";
                    }
                }

                OnPropertyChanged("SelectedAuction");
            }
        }
        public ObservableCollection<Auction> Auctions
        {
            get => this._auctions;
            set
            {
                this._auctions = value;
                OnPropertyChanged("Auctions");
            }
        }
        public string AuctionButtonContent
        {
            get => this._auctionButtonContent;
            set
            {
                this._auctionButtonContent = value;
                OnPropertyChanged("AuctionButtonContent");
            }
        }

        public ICommand AuctionButtonCommand { get; set; }
        public AuctionViewModel(BusinessGoods logicGoods, BusinessAuction logicAuction, MainViewModel mainViewModel)
        {
            this.logicGoods = logicGoods;
           
            this.logicAuction = logicAuction;
            this._mainViewModel = mainViewModel;
            AuctionButtonCommand = new ActiveCahngeCommand(this, this._mainViewModel);
            LoadData();

        }

        public void LoadData()
        {
            List<Auction> auctions = this.logicAuction.GetAllAuctions();
            foreach (Auction auction in auctions)
            {
                Auctions.Add(auction);
            }
        }

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
