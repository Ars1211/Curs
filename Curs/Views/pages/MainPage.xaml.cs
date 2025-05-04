
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

namespace Curs.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MyFrame.Content = new DashPage();
        }

        private void FramePage(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new DashPage();
        }

        

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new SettingsPage();
        }

        private void FramePage2(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new BookDatabase();
        }

        private void FramePage3(object sender, RoutedEventArgs e)
        {
           MyFrame.Content = new WishList();
        }

        private void FramePage4(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new BingoPage();
        }

        private void FramePage5(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new GuidePage();
        }

        private void FramePage6(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new ReadPage();
        }
    }
}
