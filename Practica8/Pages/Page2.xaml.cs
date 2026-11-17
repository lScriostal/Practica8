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
            ListBox2.Items.Add("Электрический");
            ListBox2.Items.Add("Гибридный");

            if(!string.IsNullOrEmpty(AppData.SelectedModel))
                ListBox1.SelectedItem = AppData.SelectedModel;
            if(!string.IsNullOrEmpty(AppData.SelectedEngine))
                ListBox2.SelectedItem = AppData.SelectedEngine;
        }

        private void EngineButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(ListBox1.SelectedItem == null || ListBox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите модель автомобиля и тип двигателя!", "Внимание");
                return;
            }

            if (ListBox1.SelectedItem != null)
                AppData.SelectedModel = ListBox1.SelectedItem.ToString();

            if (ListBox2.SelectedItem != null)
                AppData.SelectedEngine = ListBox2.SelectedItem.ToString();

            if (AppData.SelectedModel == "BMW") AppData.ModelBasePrice = 3000000m;
            else if (AppData.SelectedModel == "Mercedes") AppData.ModelBasePrice = 3500000m;
            else if (AppData.SelectedModel == "Audi") AppData.ModelBasePrice = 2800000m;
            else if (AppData.SelectedModel == "LADA") AppData.ModelBasePrice = 800000m;
            else AppData.ModelBasePrice = 2000000m;

            if (AppData.SelectedEngine == "Бензиновый") AppData.EnginePrice = 0m;
            else if (AppData.SelectedEngine == "Дизельный") AppData.EnginePrice = 150000m;
            else if (AppData.SelectedEngine == "Электрический") AppData.EnginePrice = 500000m;
            else AppData.EnginePrice = 3000000m;

            NavigationService.Navigate(new Page3());
        }
    }
}
