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
    /// Логика взаимодействия для CreateBingoWindow.xaml
    /// </summary>
    public partial class CreateBingoWindow : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public CreateBingoWindow()
        {
            InitializeComponent();
        }

        private void CreateItem(object sender, RoutedEventArgs e)
        {
            Bingo bingo = new Bingo();

            bingo.Description = Description.Text;
            db.Bingo.Add(bingo);
            db.SaveChanges();
            MessageBox.Show("Сохранен");
            this.DialogResult = true;
        }
    }
}
