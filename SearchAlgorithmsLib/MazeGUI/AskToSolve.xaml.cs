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
    /// Interaction logic for AskToSolve.xaml
    /// </summary>
    public partial class AskToSolve : Window
    {
        public bool choose { get; set; }
        public AskToSolve()
        {
            InitializeComponent();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            choose = false;
            this.Close();
        }
        private void Button_Click_Solve(object sender, RoutedEventArgs e)
        {
            choose = true;
            this.Close();
        }


    }
}
