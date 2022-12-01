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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TortugasKarp.ClassHelper;
using TortugasKarp.Pages;

namespace TortugasKarp.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow(EF.Dish dishes)
        {
            InitializeComponent();
            try
            {
                LvProduct.ItemsSource = ClassHelper.AppData.context.Dish.Where(i => i.Id == dishes.Id).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txbAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var btnAddToCart = sender as TextBlock;

            if (btnAddToCart == null)
                return;

            var dish = btnAddToCart.DataContext as EF.Dish;

            if (dish == null)
                return;

            foreach (var item in Busket.dishes)
            {
                if (item == dish)
                {
                    item.Qty++;
                    item.Count += item.Cost;
                    Busket.finishCost += item.Cost;
                    return;
                }
            }
            Busket.dishes.Add(dish);
            MessageBox.Show("Блюдо добавлено");
            Close();
        }

        private void txbClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
