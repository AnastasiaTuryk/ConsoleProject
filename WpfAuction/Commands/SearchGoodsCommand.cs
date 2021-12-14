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
    internal class SearchGoodsCommand : ICommand
    {
        private GoodsViewModel _goodsViewModel;

        public SearchGoodsCommand(GoodsViewModel goodsViewModel)
        {
            this._goodsViewModel = goodsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._goodsViewModel.GoodList.Clear();
            if (parameter.ToString() == "" || parameter.ToString() == null)
            {
                foreach (Goods goods in this._goodsViewModel.logicGoods.GetAllGoods())
                {
                    this._goodsViewModel.GoodList.Add(new Tuple<Goods>(goods));
                }
            }
            else
            {
                foreach (Goods goods in this._goodsViewModel.logicGoods.GetAllGoods())
                {
                    this._goodsViewModel.GoodList.Add(new Tuple<Goods>(goods));
                }
            }
        }
    }
}
