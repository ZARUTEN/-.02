# **Название учебной практики Осуществление интеграции программных модулей**
## Оглавление 
---
1. [Основная информация](#Краткое-описание-программы)
2. [Программный продукт](#Программный-продукт)
---
## Основная информация
**Фамилия и имя студента:**  ```Виноградов Даниил Алексеевич```

**Название предметной области:** ```Осуществление интеграции программных модулей```

[:arrow_up_small:Оглавление](#Оглавление)

---
## Программный продукт
**Краткое описание программы:**
```
Программный продукт предназначен для...
Программа выполняет следующие функции:
1.Обрабатывает введенные данные пользователем
2.Запрашивает данные у SQL
3.После условие ставить конечный итог и дает доступ к программе
```
**Пример кода программы:**
```c#
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(loginTextBox.Text))
            {
                if (!String.IsNullOrEmpty(PassTextBox.Text))
                {
                    IQueryable<Авторизация> Авторизация_list = Class1.GetContext().Авторизация.Where(p => p.Логин == loginTextBox.Text && p.Пароль == PassTextBox.Text);
                    if (Авторизация_list.Count() == 1)
                    {
                        MessageBox.Show("Добро пожаловать, " + Авторизация_list.First().ФИО);
                        Window1 window = new Window1(Авторизация_list.First());
                        window.Owner = this;
                        window.Show();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window = new Window3();
            this.Hide();
            window.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
          
            
                this.Close();
          
        }
    }
}

```
[:arrow_up_small:Оглавление](#Оглавление)
