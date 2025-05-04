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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Curs.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для ReadPage.xaml
    /// </summary>
    public partial class ReadPage : Page
    {
        private BookTrackerEntities db = new BookTrackerEntities();
        public ReadPage()
        {
            InitializeComponent();
            DGBook.ItemsSource = db.Books.Where(b => b.Status == 1).ToList();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            DGBook.ItemsSource = db.Books.Where(x => x.IdBook.ToString().Contains(SearchText.Text) || x.NameBook.ToLower().Contains(SearchText.Text.ToLower()) || x.Author.ToLower().Contains(SearchText.Text.ToLower()) || x.Publication.ToLower().Contains(SearchText.Text.ToLower()) || x.IdYear.ToString().Contains(SearchText.Text) || x.Cost.ToString().Contains(SearchText.Text) || x.Genre.ToString().Contains(SearchText.Text) || x.Pages.ToString().Contains(SearchText.Text) || x.Format.ToString().Contains(SearchText.Text) || x.Status.ToString().Contains(SearchText.Text) || x.Evaluation.ToString().Contains(SearchText.Text) || x.Review.ToLower().Contains(SearchText.Text.ToLower())).ToList();

        }
    }
}
