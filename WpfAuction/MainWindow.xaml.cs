using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using DAL;
using DTO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using WpfAuction.ViewModels;

namespace WpfAuction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UnityContainer Container;
        public MainWindow()
        {
            ConfigureUnity();
            InitializeComponent();
            DataContext = Container.Resolve<MainViewModel>();
        }
        static private void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<BusinessAuction>()
                      .RegisterType<BusinessGoods>()
                      .RegisterType<BusinessUser>()
                      .RegisterType<AuctionRepository>()
                      .RegisterType<UserRepository>()
                      .RegisterType<SellerRepository>()
                      .RegisterType<GoodsRepository>()
                      .RegisterType<RoleRepository>();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        private void CloseCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}