using Curs.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace Curs.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для createWindow2.xaml
    /// </summary>
    public partial class createWindow2 : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public createWindow2()
        {
            InitializeComponent();



            var genres = db.Genres.ToList();
            genres.Insert(0, new Genres { NameGenre = "Выберите жанр" });
            CBGenre.ItemsSource = genres;
            CBGenre.DisplayMemberPath = "NameGenre";
            CBGenre.SelectedIndex = 0;

            Date.Text = "11.11.2011";
            Date.Foreground = Brushes.Gray;
        }

        private void CreateItem(object sender, RoutedEventArgs e)
        {
            Books books = new Books();
            Wishlist wishlist = new Wishlist();

            wishlist.Image = Image.Text;
            wishlist.Name = Name.Text;
            wishlist.Author = Author.Text;
            wishlist.IdGenre = CBGenre.SelectedIndex;
            wishlist.Date = Date.Text;


            db.Wishlist.Add(wishlist);
            db.SaveChanges();
            MessageBox.Show("Сохранен");
            this.DialogResult = true;
        }

        private void Date_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Date.Text == "11.11.2011")
            {
                Date.Text = "";
                Date.Foreground = Brushes.Gray;
            }
        }

        private void Date_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Date.Text == "")
            {
                Date.Text = "11.11.2011";
            }
            else if (Date.Text == "11.11.2011")
            {
                Date.Foreground = Brushes.Gray;
            }
            else
            {
                Date.Foreground = Brushes.Gray;
            }
        }

        private void Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string currentText = textBox.Text;

            if (textBox.SelectionLength > 0)
            {
                currentText = currentText.Remove(textBox.SelectionStart, textBox.SelectionLength);
                currentText = currentText.Insert(textBox.SelectionStart, e.Text);
            }
            else
            {
                currentText = currentText.Insert(textBox.SelectionStart, e.Text);
            }

           
            string digitsOnly = Regex.Replace(currentText, @"[^0-9]", "");

        
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < digitsOnly.Length && i < 8; i++)
            {
                sb.Append(digitsOnly[i]);
                if (i == 1 || i == 3)
                {
                    sb.Append('.');
                }
            }

            string newText = sb.ToString();

         
            if (newText.Length == 10)
            {
                string[] parts = newText.Split('.');
                if (parts.Length == 3)
                {
                    int day, month, year;
                    bool isDay = int.TryParse(parts[0], out day);
                    bool isMonth = int.TryParse(parts[1], out month);
                    bool isYear = int.TryParse(parts[2], out year);

                    if (isDay && isMonth && isYear)
                    {
                        try
                        {
                            DateTime dt = new DateTime(year, month, day);
                            // Если дата существует, всё хорошо
                            if (year < 1980 || year > 2025)
                            {
                                MessageBox.Show("Год должен быть в диапазоне от 1980 до 2025.");
                                e.Handled = true;
                                return;
                            }
                        }
                        catch
                        {
                            // Некорректная дата
                            MessageBox.Show("Некорректная дата. Пожалуйста, введите существующую дату.");
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }

          
            if (newText.Length > 10)
            {
                e.Handled = true;
                return;
            }
            textBox.Text = newText;
            textBox.CaretIndex = newText.Length;
            e.Handled = true; 
        }
    }
}
