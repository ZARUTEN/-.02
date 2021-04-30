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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Авторизация librarian;
        public Window1(Авторизация librarian)
        {

            InitializeComponent();


            if (!String.IsNullOrEmpty(librarian.Фото))
            {
                try
                {
                    NAMEPERSON.Content = librarian.ФИО;
                    this.librarian = librarian;
                    Image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath($"image/{librarian.Фото}")));

                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            var massive = from Услуги in Class1.GetContext().Услуги
                          select new
                          {
                              ID = Услуги.C_ID_услуги,
                              Название = Услуги.Название,
                              C_ID_услуги = Услуги.C_ID_услуги,
                              группа = Услуги.группа,
                              себестоимоть = Услуги.себестоимоть,
                              цена = Услуги.цена,
                              сотруднику = Услуги.сотруднику,
                              описание_услуги = Услуги.описание_услуги,
                          };
            DataGrid.ItemsSource = massive.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.Copy(openFileDialog.FileName, "image/" + System.IO.Path.GetFileName(openFileDialog.FileName), true);
                    librarian.Фото = System.IO.Path.GetFileName(openFileDialog.FileName);
                    Class1.GetContext().SaveChanges();
                    Class1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    try
                    {
                        Image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("image/" + librarian.Фото)));

                    }
                    catch (IOException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
                catch (IOException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           Button but = sender as Button;
           Window2 window = new Window2();
           window.Show();
           window.Owner = this;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Lable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            Window4 window = new Window4(label.Tag);
            window.Owner = this;
            window.Show();
        }
        public void UpdateData()
        {
            Class1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var massive = from Услуги in Class1.GetContext().Услуги
                          select new
                          {
                              ID = Услуги.C_ID_услуги,
                              Название = Услуги.Название,
                              C_ID_услуги = Услуги.C_ID_услуги,
                              группа = Услуги.группа,
                              себестоимоть = Услуги.себестоимоть,
                              цена = Услуги.цена,
                              сотруднику = Услуги.сотруднику,
                              описание_услуги = Услуги.описание_услуги,
                          };
            DataGrid.ItemsSource = massive.ToList();
        }
        private void Button_3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resbox = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo);
            if (resbox == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32( TypeDescriptor.GetProperties(DataGrid.SelectedItem)[0].GetValue(DataGrid.SelectedItem));
                Услуги poseh = Class1.GetContext().Услуги.Where(p => p.C_ID_услуги == id).First();
                Class1.GetContext().Услуги.Remove(poseh);
                Class1.GetContext().SaveChanges();
                UpdateData();
            }
        }
        private void Button_4(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Window5 window = new Window5(but.Tag);
            window.Owner = this;
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Window6 window = new Window6();
            window.Show();
            window.Owner = this;
        }
    }
   
}


