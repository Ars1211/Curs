using Curs.Models;
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
using System.Windows.Shapes;

namespace Curs.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для EditStatusWindow.xaml
    /// </summary>
    public partial class EditStatusWindow : Window
    {
        public EditStatusWindow(statuses statuses)
        {
            InitializeComponent();
            this.DataContext = statuses;
        }

        private void SaveItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сохранено");
            this.Close();
        }
    }
}
