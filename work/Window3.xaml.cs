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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private Авторизация librarian;
        public Window3()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Hide();
            window.Show();
        }


        private void But_Click(object sender, RoutedEventArgs e)
        {

            if (Tex1.Text != "")
            {
                if (Tex2.Text != "")
                {
                    if (Tex3.Text != "")
                    {
                        Class1.GetContext().Авторизация.Add(new Авторизация()
                        {
                            Логин = Tex1.Text,
                            Пароль = Tex2.Text,
                            ФИО = Tex3.Text,


                        });
                        Class1.GetContext().SaveChanges();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, Введите ФИО!");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, Введите Пароль!");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, Введите Логин!");
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }


    }
}
