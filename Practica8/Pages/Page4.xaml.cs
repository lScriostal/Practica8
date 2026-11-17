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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            TxtModelName.Text = AppData.SelectedModel;
            TxtModelPrice.Text = $"{AppData.ModelBasePrice:N0} руб.";

            TxtEngineName.Text = AppData.SelectedEngine;
            TxtEnginePrice.Text = AppData.EnginePrice == 0 ? "Включено" : $"+{AppData.EnginePrice:N0} руб.";

            TxtColorName.Text = AppData.SelectedColor;
            TxtColorPrice.Text = AppData.ColorPrice == 0 ? "Включено" : $"+{AppData.ColorPrice:N0} руб.";

            TxtOptionsName.Text = string.IsNullOrEmpty(AppData.SelectedOption) ? "Нет" : AppData.SelectedOption;
            TxtOptionsPrice.Text = AppData.OptionsPrice == 0 ? "0 руб." : $"+{AppData.OptionsPrice:N0} руб.";

            decimal total = AppData.ModelBasePrice + AppData.EnginePrice + AppData.ColorPrice + AppData.OptionsPrice;
            TxtTotalPrice.Text = $"{total:N0} руб.";
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            AppData.TotalCarPrice = AppData.ModelBasePrice + AppData.EnginePrice + AppData.ColorPrice + AppData.OptionsPrice;
            NavigationService.Navigate(new Page5());
        }
    }
}
