using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TortugasKarp.ClassHelper;

namespace TortugasKarp.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            LvCategory.ItemsSource = AppData.context.Category.ToList();
            LvDish.ItemsSource = AppData.context.Dish.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var btnAddToCart = sender as Button;

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
        }
        private void LvCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Category = LvCategory.SelectedItem as EF.Category;
            LvDish.ItemsSource = ClassHelper.AppData.context.Dish.Where(i => i.CategoryId == Category.Id).ToList();
        }

        private void txbOrder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new Pages.OrderPage());
        }

        private void txbBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            Busket.finishCost = 0;
            main.Show();
            this.Close();
        }

        private void txbClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void LvDish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductWindow product = new ProductWindow(LvDish.SelectedItem as EF.Dish);
            product.Show();
        }
    }
}
