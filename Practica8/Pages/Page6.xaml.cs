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
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtName == null || TxtPhone == null || TxtEmail == null || BtnSubmit == null)
                return;

            string name = TxtName.Text.Trim();
            string phone = TxtPhone.Text.Trim();
            string email = TxtEmail.Text.Trim();

            bool isNameValid = name.Length >= 2;

            bool isPhoneValid = phone.Length >= 10 && phone.Length <= 12 && phone.All(char.IsDigit);

            bool isEmailValid = email.Contains("@") && email.Contains(".");

            BtnSubmit.IsEnabled = isNameValid && isPhoneValid && isEmailValid;

            TxtError.Text = "";
            if (!isNameValid) TxtError.Text = "Имя должно содержать минимум 2 буквы.";
            else if (!isPhoneValid) TxtError.Text = "Телефон должен состоять только из цифр (10-12 шт.).";
            else if (!isEmailValid) TxtError.Text = "Введите корректный Email (с символом @ и .).";
        }

        private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
        {
            AppData.ClientName = TxtName.Text.Trim();
            AppData.ClientPhone = TxtPhone.Text.Trim();
            AppData.ClientEmail = TxtEmail.Text.Trim();

            MessageBox.Show(
                $"Заявка успешно оформлена!\n\n" +
                $"Клиент: {AppData.ClientName}\n" +
                $"Телефон: {AppData.ClientPhone}\n" +
                $"Email: {AppData.ClientEmail}\n\n" +
                $"Автомобиль: {AppData.SelectedModel} ({AppData.SelectedEngine})\n" +
                $"Итог: {AppData.TotalCarPrice:N0} руб.",
                "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (BtnSubmit.IsEnabled)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Вы уверены, что хотите уйти? Введённые данные будут потеряны.",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
            if (NavigationService.CanGoBack) 
            { 
                NavigationService.GoBack();
            }
        }
    }
}
