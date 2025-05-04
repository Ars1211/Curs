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
    /// Логика взаимодействия для CreateNewFormat.xaml
    /// </summary>
    public partial class CreateNewFormat : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public CreateNewFormat()
        {
            InitializeComponent();
        }

        private void CreateItem(object sender, RoutedEventArgs e)
        {
            Formats formats = new Formats();

            formats.NameFormat = NameFormat.Text;
            db.Formats.Add(formats);
            db.SaveChanges();
            MessageBox.Show("Сохранен");
            this.DialogResult = true;
        }
    }
}
