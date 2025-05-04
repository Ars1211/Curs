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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private BookTrackerEntities db = new BookTrackerEntities();
        public SettingsPage()
        {
            InitializeComponent();
            DGBook1.ItemsSource = db.Genres.ToList();
            DGBook2.ItemsSource = db.Formats.ToList();
            DGBook3.ItemsSource = db.statuses.ToList();
        }

    



        private void NewItem1(object sender, RoutedEventArgs e)
        {
            CreateNewGenre createNewGenre = new CreateNewGenre();

            var result = createNewGenre.ShowDialog();

            if (result == true)
            {
                DGBook1.ItemsSource = db.Genres.ToList();
            }
        }

        private void NewItem2(object sender, RoutedEventArgs e)
        {
            CreateNewFormat createNewFormat = new CreateNewFormat();

            var result = createNewFormat.ShowDialog();

            if (result == true)
            {
                DGBook2.ItemsSource = db.Formats.ToList();
            }
        }

        private void NewItem3(object sender, RoutedEventArgs e)
        {
            CreateNewStatus createNewStatus = new CreateNewStatus();

            var result = createNewStatus.ShowDialog();

            if (result == true)
            {
                DGBook3.ItemsSource = db.statuses.ToList();
            }
        }

        private void SellItem1(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Genres;

            if (db.Genres.ToList().Count() > 0)
            {

                if (selectItem != null)
                {
                    var res = MessageBox.Show("Вы уверены что хотите удалить жанр", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.Genres.Remove(selectItem);
                        db.SaveChanges();
                        DGBook1.ItemsSource = db.Genres.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите жанр");
                }
            }
            else
            {

                MessageBox.Show("Нет жанра для удаления");
            }
        }

        private void SellItem2(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Formats;

            if (db.Formats.ToList().Count() > 0)
            {

                if (selectItem != null)
                {
                    var res = MessageBox.Show("Вы уверены что хотите удалить формат", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.Formats.Remove(selectItem);
                        db.SaveChanges();
                        DGBook2.ItemsSource = db.Formats.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите формат");
                }
            }
            else
            {

                MessageBox.Show("Нет формата для удаления");
            }
        }

        private void SellItem3(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as statuses;

            if (db.statuses.ToList().Count() > 0)
            {

                if (selectItem != null)
                {
                    var res = MessageBox.Show("Вы уверены что хотите удалить статус", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.statuses.Remove(selectItem);
                        db.SaveChanges();
                        DGBook3.ItemsSource = db.statuses.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите статус");
                }
            }
            else
            {

                MessageBox.Show("Нет статуса для удаления");
            }
        }

        private void EditItem1(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Genres;
            if (db.Genres.ToList().Count() > 0)
            {
                if (selectItem != null)
                {
                    var messageBoxResult = MessageBox.Show("Вы уверены что хотите редактировать жанр?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var genres = (sender as Button).DataContext as Genres;
                        EditGenreWindow editGenreWindow = new EditGenreWindow(genres);

                        var result = editGenreWindow.ShowDialog();

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
                    MessageBox.Show("Нет карточек для редактирования");
                }
            }
        }

        private void EditItem2(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Formats;
            if (db.Formats.ToList().Count() > 0)
            {
                if (selectItem != null)
                {
                    var messageBoxResult = MessageBox.Show("Вы уверены что хотите редактировать формат?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var formats = (sender as Button).DataContext as Formats;
                        EditFormWindow editFormWindow = new EditFormWindow(formats);

                        var result = editFormWindow.ShowDialog();

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
                    MessageBox.Show("Нет форматов для редактирования");
                }
            }
        }

        private void EditItem3(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as statuses;
            if (db.statuses.ToList().Count() > 0)
            {
                if (selectItem != null)
                {
                    var messageBoxResult = MessageBox.Show("Вы уверены что хотите редактировать статус?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var statuses = (sender as Button).DataContext as statuses;
                        EditStatusWindow editStatusWindow = new EditStatusWindow(statuses);

                        var result = editStatusWindow.ShowDialog();

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
                    MessageBox.Show("Нет статусов для редактирования");
                }
            }
        }
    }
}
