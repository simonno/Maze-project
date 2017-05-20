using System.Windows;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for AskToSolve.xaml
    /// </summary>
    public partial class PopMessage : Window
    {

        public bool Choose { get; set; }
        public string RightBtnContent { get; private set; }
        public string Message { get; private set; }
        public string LeftBtnContent { get; private set; }

        public PopMessage(string message, string leftBtnContent, string rightBtnContent)
        {
            Message = message;
            LeftBtnContent = leftBtnContent;
            RightBtnContent = rightBtnContent;
            InitializeComponent();
            DataContext = this;
            ucPopQuestion.btnLeft.Click += BtnLeft_Click;
            ucPopQuestion.btnRight.Click += BtnRight_Click;
        }
        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            Choose = false;
            Close();
        }
        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            Choose = true;
            Close();
        }


    }
}
