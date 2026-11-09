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

namespace Practica8.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            ListBox1.Items.Add("Белый");
            ListBox1.Items.Add("Чёрный");
            ListBox1.Items.Add("Зелёный");
            ListBox1.Items.Add("Красный");
            ListBox1.Items.Add("Синий");
            ListBox1.Items.Add("Фиолетовый");
            ListBox1.Items.Add("Коричсневый");

            ListBox2.Items.Add("Обычная версия");
            ListBox2.Items.Add("Средняя версия");
            ListBox2.Items.Add("Максимальная версия");
            ListBox2.Items.Add("Панорамная крыша");
            ListBox2.Items.Add("Автопилот");
        }

        private void ColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }

        private void ColorEndButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}
