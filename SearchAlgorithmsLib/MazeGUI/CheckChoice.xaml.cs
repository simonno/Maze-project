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

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for CheckChoice.xaml
    /// </summary>
    public partial class CheckChoice : Window
    {
       
        public CheckChoice()
        {
            InitializeComponent();
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
          
        }
        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
