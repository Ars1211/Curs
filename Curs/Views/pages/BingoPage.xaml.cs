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
    /// Логика взаимодействия для BingoPage.xaml
    /// </summary>
    public partial class BingoPage : Page
    {
        private BookTrackerEntities db = new BookTrackerEntities();
        public BingoPage()
        {
            InitializeComponent();
            ICBingo.ItemsSource = db.Bingo.ToList();
            
            

        }


        private void Edit(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Bingo;
            if (db.Bingo.ToList().Count() > 0)
            {
                if (selectItem != null)
                {
                    var messageBoxResult = MessageBox.Show("Вы уверены что хотите редактировать карточку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        var bingo = (sender as Button).DataContext as Bingo;
                        EditBingoWindow editBingoWindow = new EditBingoWindow(bingo);

                        var result = editBingoWindow.ShowDialog();

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

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            var selectItem = (sender as Button).DataContext as Bingo;

            if (db.Bingo.ToList().Count() > 0)
            {

                if (selectItem != null)
                {
                    var res = MessageBox.Show("Вы уверены что хотите удалить карточку", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.Bingo.Remove(selectItem);
                        db.SaveChanges();
                        ICBingo.ItemsSource = db.Bingo.ToList();
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

        private void NewItem(object sender, RoutedEventArgs e)
        {
            CreateBingoWindow createBingoWindow = new CreateBingoWindow();

            var result = createBingoWindow.ShowDialog();

            if (result == true)
            {
                ICBingo.ItemsSource = db.Bingo.ToList();
            }
        }

   

        private void Check2_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var selectItem = btn.DataContext as Bingo;
            if (selectItem != null)
            {
                selectItem.IsCompleted = !selectItem.IsCompleted;
                db.SaveChanges();
                
                ICBingo.ItemsSource = db.Bingo.ToList();
            }

            

            var template = btn.Template;
            var circle = template.FindName("Circle", btn) as Ellipse;
            var check = template.FindName("CheckMark", btn) as Path;
            if (selectItem.IsCompleted)
            {
                if (circle != null) circle.Fill = new SolidColorBrush(Color.FromRgb(30, 180, 50));
                if (check != null) check.Opacity = 1;
            }
            else
            {
                if (circle != null) circle.Fill = Brushes.Transparent;
                if (check != null) check.Opacity = 0;
            }
        }
    }
}
