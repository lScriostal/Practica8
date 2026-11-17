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

namespace Practica8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public static class AppData
    {
        public static string SelectedModel { get; set; }
        public static decimal ModelBasePrice { get; set; }
        public static string SelectedEngine { get; set; }
        public static decimal EnginePrice { get; set; }
        public static string SelectedColor { get; set; }
        public static decimal ColorPrice { get; set; }
        public static string SelectedOption { get; set; }
        public static decimal OptionsPrice { get; set; }
        public static decimal TotalCarPrice { get; set; }
        public static string ClientName { get; set; }
        public static string ClientPhone { get; set; }
        public static string ClientEmail { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigated += MainFrame_Navigated;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainFrame.Content is Page currentPage)
            {
                string pageName = currentPage.GetType().Name;
                int stepNumber = 1;

                switch (pageName)
                {
                    case "Page1": stepNumber = 0; break;
                    case "Page2": stepNumber = 1; break;
                    case "Page3": stepNumber = 2; break;
                    case "Page4": stepNumber = 3; break;
                    case "Page5": stepNumber = 4; break;
                    case "Page6": 
                        stepNumber = 5;
                        break;
                }

                StepProgressBar.Value = stepNumber;
            }
        }
    }
}
