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

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for SingleDetailsPage.xaml
    /// </summary>
    public partial class SingleDetailsPage : Page
    {
        public SingleDetailsPage()
        {
            InitializeComponent();
        }

        //private void TextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (sender is TextBox tb)
        //    {
        //        if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "[^0-9]"))
        //        {
        //            MessageBox.Show("Please enter only numbers.");
        //            tb.Clear();
        //        }
        //    }
        //}

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = MazeDetails.txtBoxName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please insert a name for the maze");
                return;
            }

            string rows = MazeDetails.txtBoxRows.Text;
            if (string.IsNullOrEmpty(rows))
            {
                MessageBox.Show("Please insert the number of the maze's rows.");
                return;
            }

            string columns = MazeDetails.txtBoxColumns.Text;
            if (string.IsNullOrEmpty(columns))
            {
                MessageBox.Show("Please insert the number of the maze's columns.");
                return;
            }

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("SingleGamePage.xaml", UriKind.Relative));
        }
    }
}
