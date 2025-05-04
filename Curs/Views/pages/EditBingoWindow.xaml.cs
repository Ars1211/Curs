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
    /// Логика взаимодействия для EditBingoWindow.xaml
    /// </summary>
    public partial class EditBingoWindow : Window
    {
        
        public EditBingoWindow(Bingo bingo)
        {
            InitializeComponent();
            this.DataContext = bingo;
        }

        private void SaveItem(object sender, RoutedEventArgs e)
        {
            Bingo bingo = new Bingo();
            MessageBox.Show("Сохранено");
            this.Close();
        }
    }
}
