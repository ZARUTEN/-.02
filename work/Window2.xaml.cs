using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        
        public Window2()
        {
            InitializeComponent();
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class1.GetContext().Услуги.Add(new Услуги()
            {
            Название = Tex1.Text,
            группа = Tex2.Text,
            себестоимоть = Tex3.Text,
            цена = Tex4.Text,
            сотруднику = Tex5.Text,
            описание_услуги = Tex6.Text,
            });
            Class1.GetContext().SaveChanges();
            ((Window1)this.Owner).UpdateData();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {    

        }
    }
}