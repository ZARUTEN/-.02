using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private int Ids;
        public Window4(object id)
        {
            InitializeComponent();     
            Ids = (int)id;
            var result = Class1.GetContext().Услуги.Where(p => p.C_ID_услуги == Ids);
            tex1.Text = id.ToString();
            tex1.Text = result.First().Название;
            tex2.Text = result.First().цена;
            tex3.Text = result.First().описание_услуги;


            if (!String.IsNullOrEmpty(result.First().Фото_услуги))
            {
                try
                {
                    Image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("image/" + result.First().Фото_услуги)));
                }
                catch (IOException ex)
                {
                   MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
