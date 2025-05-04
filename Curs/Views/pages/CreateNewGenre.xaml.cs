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
    /// Логика взаимодействия для CreateNewGenre.xaml
    /// </summary>
    public partial class CreateNewGenre : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public CreateNewGenre()
        {
            InitializeComponent();
        }

        private void CreateItem(object sender, RoutedEventArgs e)
        {
            Genres genres = new Genres();

            genres.NameGenre = NameGenre.Text;
            db.Genres.Add(genres);
            db.SaveChanges();
            MessageBox.Show("Сохранен");
            this.DialogResult = true;
        }
    }
}
