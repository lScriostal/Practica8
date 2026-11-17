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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        private const double AnnualInterestRate = 15.0;

        public Page5()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCalculations();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TxtInitialPercent != null && TxtTermMonths != null)
            {
                UpdateCalculations();
            }
        }

        private void UpdateCalculations()
        {
            if (SliderInitial == null || SliderTerm == null ||
        TxtInitialPercent == null || TxtTermMonths == null ||
        TxtInitialSum == null || TxtCreditSum == null || TxtMonthlyPayment == null)
            {
                return;
            }

            double initialPercent = SliderInitial.Value;
            int termMonths = (int)SliderTerm.Value;

            TxtInitialPercent.Text = $"{initialPercent}%";
            TxtTermMonths.Text = $"{termMonths} мес.";

            decimal totalPrice = AppData.TotalCarPrice;

            decimal initialSum = totalPrice * (decimal)(initialPercent / 100);
            decimal creditSum = totalPrice - initialSum;

            TxtInitialSum.Text = $"Сумма взноса: {initialSum:N0} руб.";
            TxtCreditSum.Text = $"{creditSum:N0} руб.";

            if (creditSum <= 0)
            {
                TxtMonthlyPayment.Text = "0 руб.";
                return;
            }

            double monthlyRate = (AnnualInterestRate / 100) / 12; 
            double n = termMonths;

            double monthlyPayment = (double)creditSum * (monthlyRate * Math.Pow(1 + monthlyRate, n)) / (Math.Pow(1 + monthlyRate, n) - 1);

            TxtMonthlyPayment.Text = $"{monthlyPayment:N0} руб.";
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page6()); 
            MessageBox.Show("Переход к оформлению заявки!");
        }
    }
}
