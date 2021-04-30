using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace work
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
            var massive = from Авторизация in Class1.GetContext().Авторизация
                          select new
                          {
                              ID = Авторизация.ID_пользователя,
                              Логин = Авторизация.Логин,
                              Пароль = Авторизация.Пароль,
                          };
            DataGrid.ItemsSource = massive.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resbox = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo);
            if (resbox == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(TypeDescriptor.GetProperties(DataGrid.SelectedItem)[0].GetValue(DataGrid.SelectedItem));
                Авторизация poseh = Class1.GetContext().Авторизация.Where(p => p.ID_пользователя == id).First();
                Class1.GetContext().Авторизация.Remove(poseh);
                Class1.GetContext().SaveChanges();
                UpdateDaata();
            }
        }

        public void UpdateDaata()
        {
            Class1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var massive = from Авторизация in Class1.GetContext().Авторизация
                          select new
                          {
                              Логин = Авторизация.Логин,
                              Пароль = Авторизация.Пароль,
                          };
            DataGrid.ItemsSource = massive.ToList();
        }
    }
}
