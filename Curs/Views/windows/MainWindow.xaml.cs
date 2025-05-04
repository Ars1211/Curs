using Curs.Views.pages;
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


namespace Curs
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            AuthFrame.NavigationService.Navigate(new MainPage());
        }

        private void AuthFrameContentRendered(object sender, EventArgs e)
        {

        }
    }
}
