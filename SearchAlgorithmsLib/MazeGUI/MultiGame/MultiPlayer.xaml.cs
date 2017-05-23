﻿using System;
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

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private MultiPlayerViewModel vm;
        public MultiPlayer()
        {
            InitializeComponent();
           // vm = new MultiPlayerViewModel(model);
            vm = new MultiPlayerViewModel(new ApplicationMultiPlayerModel());

            DataContext = vm;

        //    vm = new SinglePlayerViewModel(new ApplicationSinglePlayerModel(mazeName, rows, cols));
            
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            Close();
        }

        
    }
}
