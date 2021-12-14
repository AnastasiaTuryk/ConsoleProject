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
    internal class GetAllGoods : ICommand
    {
        private GoodsViewModel _productViewModel;

        public GetAllGoods(GoodsViewModel productViewModel)
        {
            this._productViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._productViewModel.GoodList.Clear();
            foreach (Goods product in this._productViewModel.logicGoods.GetAllGoods())
            {
                this._productViewModel.GoodList.Add(new Tuple< Goods>(product));
            }
        }
    }
}
