using Curs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditWindow2.xaml
    /// </summary>
    public partial class EditWindow2 : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public EditWindow2(Wishlist wishlist)
        {
            InitializeComponent();
            this.DataContext = wishlist;
            var genres = db.Genres.ToList();

            CBGenre.ItemsSource = genres;
            CBGenre.DisplayMemberPath = "NameGenre";
            CBGenre.SelectedIndex = 0;
        }

        private void SaveItem(object sender, RoutedEventArgs e)
        {
            Wishlist wishlist = new Wishlist();
            MessageBox.Show("Сохранено");
            this.Close();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
