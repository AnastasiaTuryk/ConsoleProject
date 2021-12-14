using BusinessLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.Commands;

namespace WpfAuction.ViewModels
{
    public class GoodsViewModel : BaseViewModel, INotifyPropertyChanged, IDataErrorInfo
    {

        private Goods _selectedGoods;
        
        private Tuple<Goods> _selectedItem;
        private string _stratPrice;
        private string _endPrice;
        private string _endTime;
        private BusinessGoods _logicGoods;
       
        private MainViewModel _mainViewModel;
        private bool _buttonCreateIsEnable;
        private ObservableCollection<Tuple<Goods>> GoodsList = new ObservableCollection<Tuple<Goods>>();
        public ICommand SearchGoodsCommand { get; set; }
        public ICommand CreateAuctionCommand { get; set; }
        public IEnumerable<Goods> Goods { get; set; }
        public BusinessGoods logicGoods { get => this._logicGoods; }

        public GoodsViewModel(BusinessGoods goodslogic, MainViewModel mainViewModel)
        {
            this._logicGoods = goodslogic;
            this._mainViewModel = mainViewModel;
            LoadData();

        }

        #region Properties
        public MainViewModel MainViewModel
        {
            get => this._mainViewModel;
        }
        public Goods SelectedGoods
        {
            get { return this._selectedGoods; }
            set
            {
                this._selectedGoods = value;
                OnPropertyChanged("SelectedGoods");
            }
        }
        
        public Tuple< Goods> SelectedItem
        {
            get { return this._selectedItem; }
            set
            {
                this._selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<Tuple<Goods>> GoodList
        {
            get => this.GoodsList;
            set
            {
                this.GoodsList = value;
                OnPropertyChanged("GoodList");
            }
        }

        public string AuctionStartPrice
        {
            get => this._stratPrice;
            set
            {
                this._stratPrice = value;
                OnPropertyChanged("AuctionStartPrice");
            }
        }
        public string AuctionEndPrice
        {
            get => this._endPrice;
            set
            {
                this._endPrice = value;
                OnPropertyChanged("AuctionEndPrice");
            }
        }
        public string AuctionEndTime
        {
            get => this._endTime;
            set
            {
                this._endTime = value;
                OnPropertyChanged("AuctionEndTime");
            }
        }

        public bool ButtonCreateIsEnable
        {
            get => this._buttonCreateIsEnable;
            set
            {
                this._buttonCreateIsEnable = value;
                OnPropertyChanged("ButtonCreateIsEnable");
            }
        }
        #endregion

        #region Methods
        public void LoadData()
        {
            Goods = this._logicGoods.GetAllGoods();
            foreach (Goods product in Goods)
            {
                GoodList.Add(new Tuple< Goods>(product));
            }
            CreateAuctionCommand = new CreateAuctionCommand(this, this._mainViewModel);
            SearchGoodsCommand = new SearchGoodsCommand(this);
        }
        #endregion

        #region Validation

        private float _startPrice;
        private float _endprice;
        private DateTime _EndTime;

        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private bool _isValidPrice1 { get; set; }
        private bool _isValidPrice2 { get; set; }
        private bool _isValidEndTime { get; set; }

        public bool IsValidPrice1
        {
            get => this._isValidPrice1;
            set
            {
                if (this._isValidPrice1 != value)
                    this._isValidPrice1 = value;
            }
        }
        public bool IsValidPrice2
        {
            get => this._isValidPrice2;
            set
            {
                if (this._isValidPrice2 != value)
                    this._isValidPrice2 = value;
            }
        }
        public bool IsValidEndTime
        {
            get => this._isValidEndTime;
            set
            {
                if (this._isValidEndTime != value)
                    this._isValidEndTime = value;
            }
        }
        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "AuctionStartupPrice":
                        if (string.IsNullOrWhiteSpace(AuctionStartPrice))
                        {
                            _result = "Price cannot be empty";
                            IsValidPrice1 = false;
                        }
                        else if (!float.TryParse(AuctionStartPrice, out this._startPrice))
                        {
                            _result = "Entered data is not float type";
                            IsValidPrice1 = false;
                        }
                        else if (float.Parse(AuctionStartPrice) < 0)
                        {
                            _result = "Price must be positive";
                            IsValidPrice1 = false;
                        }
                        else
                        {
                            IsValidPrice1 = true;
                        }
                        break;
                    case "AuctionRedemptionPrice":
                        if (string.IsNullOrWhiteSpace(AuctionEndPrice))
                        {
                            _result = "Price cannot be empty";
                            IsValidPrice2 = false;
                        }
                        else if (!float.TryParse(AuctionEndPrice, out this._endprice))
                        {
                            _result = "Entered data is not float type";
                            IsValidPrice2 = false;
                        }
                        else if (float.Parse(AuctionEndPrice) < 0)
                        {
                            _result = "Price must be positive";
                            IsValidPrice2 = false;
                        }
                        else
                        {
                            IsValidPrice2 = true;
                        }
                        break;
                    case "AuctionEndTime":
                        if (string.IsNullOrWhiteSpace(AuctionEndTime))
                        {
                            _result = "Date cannot be empty";
                            IsValidEndTime = false;
                        }
                        else if (!DateTime.TryParse(AuctionEndTime, out this._EndTime))
                        {
                            _result = "Entered data is not Date time format";
                            IsValidEndTime = false;
                        }
                        else
                        {
                            IsValidEndTime = true;
                        }
                        break;

                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = _result;
                else if (_result != null)
                    ErrorCollection.Add(name, _result);
                if (IsValidPrice1 && IsValidPrice2 && IsValidEndTime)
                    ButtonCreateIsEnable = true;
                else
                    ButtonCreateIsEnable = false;

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
