using Curs.Models;
using Curs.Views.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Логика взаимодействия для BookDatabase.xaml
    /// </summary>
    public partial class BookDatabase : Page
    {
        private BookTrackerEntities db = new BookTrackerEntities();
        public BookDatabase()
        {
            InitializeComponent();
            DGBook.ItemsSource = db.Books.ToList();
        }

        private void SellItem(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Books;




            if (db.Books.ToList().Count() > 0)
            {

                if (selectItem != null)
                {
                    var res = MessageBox.Show("Вы уверены что хотите удалить книгу", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.Books.Remove(selectItem);
                        db.SaveChanges();
                        DGBook.ItemsSource = db.Books.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите книгу");
                }
            }
            else
            {

                MessageBox.Show("Нет книг для удаления");
            }

        }

        private void EditItem(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Books;
            if (db.Books.ToList().Count() > 0)
            {
                if (selectItem != null)
                {
                    var messageBoxResult = MessageBox.Show("Вы уверены что хотите редактировать книгу?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var books = (sender as Button).DataContext as Books;
                        EditWindow editWindow = new EditWindow(books);

                        var result = editWindow.ShowDialog();

                        if (result == false)
                        {

                            db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("dgdg");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Нет книг для редактирования");
                }
            }



        }




        private void NewItem(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow();

            var result = createWindow.ShowDialog();

            if (result == true)
            {
                DGBook.ItemsSource = db.Books.ToList();
            }


        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
           DGBook.ItemsSource = db.Books.Where(x => x.IdBook.ToString().Contains(SearchText.Text) || x.NameBook.ToLower().Contains(SearchText.Text.ToLower()) || x.Author.ToLower().Contains(SearchText.Text.ToLower()) || x.Publication.ToLower().Contains(SearchText.Text.ToLower()) || x.IdYear.ToString().Contains(SearchText.Text) || x.Cost.ToString().Contains(SearchText.Text) || x.Genre.ToString().Contains(SearchText.Text) || x.Pages.ToString().Contains(SearchText.Text) || x.Format.ToString().Contains(SearchText.Text) || x.Status.ToString().Contains(SearchText.Text) || x.Evaluation.ToString().Contains(SearchText.Text) || x.Review.ToLower().Contains(SearchText.Text.ToLower())).ToList();
        }



    }
}
