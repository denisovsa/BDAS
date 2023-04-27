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

using Kingsman.ClassHelper;

namespace Kingsman.Windows.LogIn
{
    /// <summary>
    /// Логика взаимодействия для SerWindow.xaml
    /// </summary>
    public partial class SerWindow : Window
    {
        public SerWindow()
        {
            InitializeComponent();
            GetListService();
        }

        // получиние списка услуг
        private void GetListService()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        // добавление услуги
        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            addServiceWindow.ShowDialog();

            // Обновляем лист
            GetListService();
        }

        // радактирование услуги
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись

            EditServiceWindow editServiceWindow = new EditServiceWindow(service);
            editServiceWindow.ShowDialog();

            GetListService();
        }

        // добавление в корзину
        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись


            CartServiceClass.ServiceCart.Add(service);

            MessageBox.Show($"Услуга {service.Name} добавлена в корзину!");
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.ShowDialog();
        }

    }
}
