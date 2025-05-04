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
    /// Логика взаимодействия для CreateNewStatus.xaml
    /// </summary>
    public partial class CreateNewStatus : Window
    {
        BookTrackerEntities db = new BookTrackerEntities();
        public CreateNewStatus()
        {
            InitializeComponent();
        }

        private void CreateItem(object sender, RoutedEventArgs e)
        {
            
            statuses statuses = new statuses();

            statuses.StatusName = NameStatus.Text;
            db.statuses.Add(statuses);
            db.SaveChanges();
            MessageBox.Show("Сохранен");
            this.DialogResult = true;
        }
    }
}
