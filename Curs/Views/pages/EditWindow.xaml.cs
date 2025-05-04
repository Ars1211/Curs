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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public EditWindow(Books books)
        {
            InitializeComponent();
            this.DataContext = books;

            var genres = db.Genres.ToList();
            
            CBGenre.ItemsSource = genres;
            CBGenre.DisplayMemberPath = "NameGenre";
            CBGenre.SelectedIndex = 0;

            var formats = db.Formats.ToList();
            
            CBFormat.ItemsSource = formats;
            CBFormat.DisplayMemberPath = "NameFormat";
            CBFormat.SelectedIndex = 0;

            var statuses = db.statuses.ToList();
           
            CBStatus.ItemsSource = statuses;
            CBStatus.DisplayMemberPath = "StatusName";
            CBStatus.SelectedIndex = 0;

            var evaluations = db.Evaluations.ToList();
            CBEvaulation.ItemsSource = evaluations;
            CBEvaulation.DisplayMemberPath = "Evaluation";
            CBEvaulation.SelectedIndex = 0;

            var years = db.Years.ToList();

            CBYear.ItemsSource = years;
            CBYear.DisplayMemberPath = "Year";
            CBYear.SelectedIndex = 0;
        }

        private void SaveItem(object sender, RoutedEventArgs e)
        {
           Books books = new Books();
           MessageBox.Show("Сохранено");
           this.Close();





        }
    }
    
}
