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

            ListBox1.Items.Add("Белый - 0");
            ListBox1.Items.Add("Чёрный - 0");
            ListBox1.Items.Add("Зелёный - 100000");
            ListBox1.Items.Add("Красный - 100000");
            ListBox1.Items.Add("Синий - 100000");
            ListBox1.Items.Add("Фиолетовый - 100000");
            ListBox1.Items.Add("Коричневый - 100000");

            if (!string.IsNullOrEmpty(AppData.SelectedColor))
            {
                foreach (var item in ListBox1.Items)
                {
                    if (item.ToString() == AppData.SelectedColor)
                    {
                        ListBox1.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void ColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите цвет автомобиля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string colorText = ListBox1.SelectedItem.ToString();
            AppData.SelectedColor = colorText.Split('-')[0].Trim();

            if (colorText.Contains("100000"))
                AppData.ColorPrice = 100000m;
            else
                AppData.ColorPrice = 0m;

            decimal optionsSum = 0;
            string selectedOptionsList = "";

            if (ChkBasic.IsChecked == true) { optionsSum += 0; selectedOptionsList += "Обычная версия, "; }
            if (ChkMedium.IsChecked == true) { optionsSum += 20000m; selectedOptionsList += "Средняя версия, "; }
            if (ChkMax.IsChecked == true) { optionsSum += 50000m; selectedOptionsList += "Максимальная версия, "; }
            if (ChkRoof.IsChecked == true) { optionsSum += 30000m; selectedOptionsList += "Панорамная крыша, "; }
            if (ChkAutoPilot.IsChecked == true) { optionsSum += 70000m; selectedOptionsList += "Автопилот, "; }

            if (string.IsNullOrEmpty(selectedOptionsList))
                AppData.SelectedOption = "Ничего";
            else
                AppData.SelectedOption = selectedOptionsList.TrimEnd(',', ' ');

            AppData.OptionsPrice = optionsSum;

            NavigationService.Navigate(new Page4());
        }

        private void ColorEndButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                NavigationService.Navigate(new Page2());
        }
    }
}
