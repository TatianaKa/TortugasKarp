using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TortugasKarp.ClassHelper;
using TortugasKarp.Windows;

namespace TortugasKarp.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private DateTime _date;
        public OrderPage()
        {
            InitializeComponent();
            _date = DateTime.Now;
            foreach (var item in ClassHelper.Busket.dishes)
            {
                if (item.Qty==0)
                {
                    item.Qty++;
                    item.Count += item.Cost;
                    Busket.finishCost += item.Cost;
                }
            }
            Filter();
        }
        
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Filter()
        {
            LvOrder.ItemsSource = ClassHelper.Busket.dishes.ToList();
            txbFinishCost.Text = ClassHelper.CountDiscount.Sum(_date, Busket.finishCost).ToString();
            //txbFinishCost.Text = Busket.finishCost.ToString();  
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            //Content = null;
        }

        private void txbDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var txbDelete = sender as TextBlock;

            if (txbDelete == null)
                return;
            var dish = txbDelete.DataContext as EF.Dish;

            if (dish == null)
                return;
            var mes = MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mes == MessageBoxResult.Yes)
            {
               Busket.finishCost -= (decimal)dish.Cost*dish.Qty;
                Busket.dishes.Remove(dish);
                MessageBox.Show("Удалено");
            }
            Filter();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (Busket.finishCost==0)
            {
            }
            else
            {
                PayWindow payWindow = new PayWindow();
                payWindow.ShowDialog();
            }
        }

        private void txbMinus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            var txbMinus = sender as TextBlock;
            if (txbMinus == null)
                return;
            var dish = txbMinus.DataContext as EF.Dish;
            if (dish == null)
                return;
            if (dish.Qty == 1) { }
            else
            {
                dish.Qty--;
                dish.Count -= dish.Cost;
                Busket.finishCost -= dish.Cost;
                Filter();
            }
        }

        private void txbPlus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var txbPlus = sender as TextBlock;

            if (txbPlus == null)
                return;
            var dish = txbPlus.DataContext as EF.Dish;

            if (dish == null)
                return;

            dish.Qty++;
            dish.Count += dish.Cost;
            Busket.finishCost += dish.Cost;
            Filter();
        }
    }
}
