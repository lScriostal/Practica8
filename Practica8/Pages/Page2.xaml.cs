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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

            ListBox1.Items.Add("BMW");
            ListBox1.Items.Add("Mercedes");
            ListBox1.Items.Add("Audi");
            ListBox1.Items.Add("LADA");
            ListBox1.Items.Add("Toyota");

            ListBox2.Items.Add("Бензиновый");
            ListBox2.Items.Add("Дизельный");
            ListBox2.Items.Add("Элекрический");
            ListBox2.Items.Add("Гибридный");

        }

        private void EngineButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}
