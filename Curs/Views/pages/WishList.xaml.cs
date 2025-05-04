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
    /// Логика взаимодействия для WishList.xaml
    /// </summary>
    public partial class WishList : Page
    {
        private BookTrackerEntities db = new BookTrackerEntities();
        public WishList()
        {
            InitializeComponent();
            ICWish.ItemsSource = db.Wishlist.ToList();
           
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            ICWish.ItemsSource = db.Wishlist.Where(x => x.Name.Contains(SearchText.Text) || x.Author.ToLower().Contains(SearchText.Text.ToLower()) || x.Date.ToString().Contains(SearchText.Text)).ToList();
        }

        private void NewItem(object sender, RoutedEventArgs e)
        {
            createWindow2 createWindow2 = new createWindow2();

            var result = createWindow2.ShowDialog();

            if (result == true)
            {
                ICWish.ItemsSource = db.Wishlist.ToList();
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Wishlist;
            if (db.Wishlist.ToList().Count() > 0)
            {
                if (selectItem != null)
                {
                    var messageBoxResult = MessageBox.Show("Вы уверены что хотите редактировать книгу?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var wishlist = (sender as Button).DataContext as Wishlist;
                        EditWindow2 editWindow2 = new EditWindow2(wishlist);

                        var result = editWindow2.ShowDialog();

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

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Wishlist;


            if (db.Wishlist.ToList().Count() > 0)
            {

                if (selectItem != null)
                {
                    var res = MessageBox.Show("Вы уверены что хотите удалить книгу", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.Wishlist.Remove(selectItem);
                        db.SaveChanges();
                        ICWish.ItemsSource = db.Wishlist.ToList();
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
    }
}
