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
    /// Логика взаимодействия для EditGenreWindow.xaml
    /// </summary>
    public partial class EditGenreWindow : Window
    {
        public EditGenreWindow(Genres genres)
        {
            InitializeComponent();
            this.DataContext = genres;
        }

        private void SaveItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сохранено");
            this.Close();
        }
    }
}
