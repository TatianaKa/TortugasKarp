using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using TortugasKarp.ClassHelper;

namespace TortugasKarp.Windows
{
    /// <summary>
    /// Логика взаимодействия для PayWindow.xaml
    /// </summary>
    public partial class PayWindow : Window
    {
        public PayWindow()
        {
            InitializeComponent();
        }
        private void btnExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (chbCard.IsChecked == true && chbNal.IsChecked == true)
            {
                MessageBox.Show("Нельзя выбрать сразу два пункта");

            }
            else if (chbCard.IsChecked == true || chbNal.IsChecked == true)
            {
                EF.Order order = new EF.Order();
                order.FinishCost = Busket.finishCost;
                order.TableId = MainWindow.numTable;
                order.DateOrder = DateTime.Now;
                ClassHelper.AppData.context.Order.Add(order);
                AppData.context.SaveChanges();
                foreach (var item in ClassHelper.Busket.dishes)
                {
                    EF.OrderDish orderDish = new EF.OrderDish();
                    orderDish.DishId = item.Id;
                    orderDish.OrderId = order.Id;
                    orderDish.Qty = item.Qty;
                    ClassHelper.AppData.context.OrderDish.Add(orderDish);
                    AppData.context.SaveChanges();
                }
                MessageBox.Show("Оплата успешно прошла");
                MainWindow main = new MainWindow();
                List<EF.Dish> dishes = new List<EF.Dish>();
                Busket.dishes=dishes;
                Busket.finishCost = 0;
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите способ оплаты");
            }

        }
    }
}
