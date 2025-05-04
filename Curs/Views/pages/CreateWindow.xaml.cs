using Curs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Text.RegularExpressions;

namespace Curs.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        BookTrackerEntities db = new BookTrackerEntities(); 
        public CreateWindow()
        {
            InitializeComponent();
            var genres = db.Genres.ToList();
            genres.Insert(0, new Genres { NameGenre = "Выберите жанр" });
            CBGenre.ItemsSource = genres;
            CBGenre.DisplayMemberPath = "NameGenre";
            CBGenre.SelectedIndex = 0;

            var formats = db.Formats.ToList();
            formats.Insert(0, new Formats { NameFormat = "Выберите формат" });
            CBFormat.ItemsSource = formats;
            CBFormat.DisplayMemberPath = "NameFormat";
            CBFormat.SelectedIndex = 0;

            var statuses = db.statuses.ToList();
            statuses.Insert(0, new statuses { StatusName = "Выберите статус" });
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

        private void CreateItem(object sender, RoutedEventArgs e)
        {
            Books books = new Books();

            books.NameBook = Name.Text;
            books.Author = Author.Text;
            books.Publication = Publication.Text;
            books.IdYear = CBYear.SelectedIndex+1;
            
                books.Cost = Convert.ToDouble(Cost.Text);
            
            
            books.Genre = CBGenre.SelectedIndex;
            books.Pages = Convert.ToInt32(Pages.Text);
            books.Format = CBFormat.SelectedIndex;
            books.Status = CBStatus.SelectedIndex;
            books.Evaluation = Convert.ToInt32(CBEvaulation.SelectedIndex+1);
            books.Review = Review.Text;



            db.Books.Add(books);
            db.SaveChanges();
            MessageBox.Show("Сохранен");
            this.DialogResult = true;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
