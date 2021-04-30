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

namespace work
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5(object id)
        {
            InitializeComponent();
            MessageBox.Show("Вы выбрали строку, " + id.ToString());
            DataContext = Class1.GetContext().Услуги.Where(p => p.C_ID_услуги == (int)id).First();
       
 
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class1.GetContext().SaveChanges();
            ((Window1)this.Owner).UpdateData();
            this.Close();
        }
    }
    }
