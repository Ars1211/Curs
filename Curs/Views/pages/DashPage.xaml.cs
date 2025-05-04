using Curs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LiveCharts;
using LiveCharts.Wpf;


namespace Curs.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для DashPage.xaml
    /// </summary>
    public partial class DashPage : Page
    {
        private BookTrackerEntities db = new BookTrackerEntities();
        public DashPage()
        {
            InitializeComponent();
            NameBookComboBox.ItemsSource = db.Books.ToList();
            NameBookComboBox.DisplayMemberPath = "NameBook";
            NameBookComboBox.SelectedIndex = 0;
            ShowSelectedBookInfo();
            


            int readBooksCount = db.Books.Count(b => b.Status == 1);
            CountTB.Text = readBooksCount.ToString();
            int readBooksCount2 = db.Books.Count(b => b.Status == 1) * 100 / db.Books.Count();
            CountPTB.Text = readBooksCount2.ToString();

            int totalReadPages = db.Books.Where(b => b.Status == 1).Sum(b => (int?)b.Pages) ?? 0;
            CountPages.Text = totalReadPages.ToString();

            int totalBooks = db.Books.Count();
            PlanTB.Text = totalBooks.ToString();

            int totalBooksTo = db.Books.Count(b => b.Status == 3);
            AllBooksTo.Text = totalBooksTo.ToString();


            var favoriteFormatId = db.Books.GroupBy(b => b.Format).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            string favoriteFormatName = db.Formats.Where(f => f.IdFormat == favoriteFormatId).Select(f => f.NameFormat).FirstOrDefault();
            FavoriteFormatTB.Text = favoriteFormatName.ToString();


            var favoriteGenreId = db.Books
                .Where(b => b.Status == 1)
                .GroupBy(b => b.Genre)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            string favoriteGenreName = db.Genres
                .Where(g => g.IdGenre == favoriteGenreId)
                .Select(g => g.NameGenre)
                .FirstOrDefault();

            FavoriteGenreTB.Text = favoriteGenreName.ToString();

            var favoriteAuthorId = db.Books
                .Where(b => b.Status == 1)
                .GroupBy(b => b.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            FavoriteAuthorTB.Text = favoriteAuthorId.ToString();

            var favoritePublisher = db.Books
                
                .GroupBy(b => b.Publication)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            FavoritePubTB.Text = favoritePublisher.ToString();

            var libraryCost = db.Books.Sum(b => (int?)b.Cost) ?? 0;
            CostAllTB.Text = libraryCost.ToString();


            int totalBooksBr = db.Books.Count(b => b.Status == 5);
            AllBookBrTB.Text = totalBooksBr.ToString();

            var biggestBook = db.Books.OrderByDescending(b => b.Pages).FirstOrDefault();
            VBookMaxTB.Text = biggestBook.NameBook;
                //+ "\n" + biggestBook.Pages;

            var minBook = db.Books.OrderBy(b => b.Pages).FirstOrDefault();
            VBokMinTB.Text = minBook.NameBook;

            var avgBook = db.Books.Average(b => (int?)b.Pages);
            int avgPages = avgBook.HasValue ? (int)Math.Round(avgBook.Value) : 0;
            AvgVBookTB.Text = avgPages.ToString();

            var rereadCount = db.Books.Count(b => b.Status == 6);
            var totalCount = db.Books.Count();

            int percent = totalCount > 0
                ? (int)Math.Round(rereadCount * 100.0 / totalCount)
                : 0;

            BookGTB.Text = percent.ToString();


            int readGenresCount = db.Books
                .Where(b => b.Status == 1) 
                .Select(b => b.Genre)
                .Distinct()
                .Count();
            AllGenreTB.Text = readGenresCount.ToString();

            int readFormatsCount = db.Books
                .Where(b => b.Status == 1) 
                .Select(b => b.Format)
                .Distinct()
                .Count();
            AllFormatTB.Text = readFormatsCount.ToString();

            var cheapestReadBook = db.Books
                .Where(b => b.Status == 1) 
                .OrderBy(b => b.Cost)
                .FirstOrDefault();
            AllCostTB.Text = cheapestReadBook.NameBook;





            //Рейтинг диаграмма

            var ratingStats = db.Books.GroupBy(b => b.Evaluation).Select(g => new { Rating = g.Key, Count = g.Count() }).ToList();

            
            var values = new ChartValues<int>();
            var labels = new List<string>();

            
            for (int i = 1; i <= 5; i++)
            {
                var stat = ratingStats.FirstOrDefault(r => r.Rating == i);
                values.Add(stat != null ? stat.Count : 0);
                labels.Add(i.ToString());
            }

            RatingChart.Series = new SeriesCollection
            {
            new ColumnSeries
            {

                Title = "Количество книг",
                Values = values,
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 18,
                
            }
            };

            RatingChart.AxisX.Add(new Axis
            {
                Title = "Оценка",
                Labels = labels,
                Foreground = new SolidColorBrush(Colors.White),
                 FontSize = 18

            });

            RatingChart.AxisY.Add(new Axis
            {
                Title = "Кол-во книг",
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 18
            });




            var topGenres = db.Books
                .Where(b => b.Status == 1)
                .GroupJoin(db.Genres,
                    b => b.Genre,
                    g => g.IdGenre,
                    (b, g) => new { b, g })
                .SelectMany(
                    bg => bg.g.DefaultIfEmpty(),
                    (bg, g) => new { GenreName = g.NameGenre }
                )
                .GroupBy(x => x.GenreName)
                .Select(g => new { GenreName = g.Key, ReadCount = g.Count() })
                .OrderByDescending(g => g.ReadCount)
                .Take(10) 
                .ToList();

            
            var pieSeries = new SeriesCollection();

            foreach (var genre in topGenres)
            {
                pieSeries.Add(new PieSeries
                {
                    Title = genre.GenreName,
                    Values = new ChartValues<decimal> { genre.ReadCount },
                    DataLabels = true,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontSize = 18
                });
            }

           
            RatingChart2.Series = pieSeries;

            
            RatingChart.AxisX.Clear();
            RatingChart.AxisY.Clear();

























        }

        private void NameBookComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedBookInfo();
        }

        private void ShowSelectedBookInfo()
        {
            var selectedBook = NameBookComboBox.SelectedItem as Books;
            if (selectedBook != null)
            {
               
                AuthorTextBox.Text = selectedBook.Author;
                GenreTextBox.Text = selectedBook.Genres.NameGenre.ToString();
                FormatTextBox.Text = selectedBook.Formats.NameFormat.ToString();
                StatusTextBox.Text = selectedBook.statuses.StatusName.ToString();
                EvaluationTextBox.Text = selectedBook.Evaluation.ToString();
                PagesTextBlock.Text = selectedBook.Pages.ToString();
                ReviewTextBox.Text = selectedBook.Review;

                int stars = 0;
                int.TryParse(selectedBook.Evaluation.ToString(), out stars);
                stars = Math.Max(0, Math.Min(5, stars)); // Ограничиваем 0..5

                string starString = new string('★', stars) + new string('☆', 5 - stars);
                EvaluationTextBox.Text = starString;

                try
                {
                    if (!string.IsNullOrWhiteSpace(selectedBook.Image))
                    {
                        
                        var imageUri = new Uri(System.IO.Path.GetFullPath(selectedBook.Image));
                        ImageBox.Source = new BitmapImage(imageUri);
                    }
                    else
                    {
                        ImageBox.Source = null; 
                    }
                }
                catch
                {
                    ImageBox.Source = null; 
                }

            }
            else
            {
                AuthorTextBox.Text = "";
                GenreTextBox.Text = "";
                FormatTextBox.Text = "";
                StatusTextBox.Text = "";
                EvaluationTextBox.Text = "";
                ReviewTextBox.Text = "";
            }
        }

        





    }
}
