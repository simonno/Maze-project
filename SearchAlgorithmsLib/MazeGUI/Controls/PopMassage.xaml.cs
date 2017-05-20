using System.Windows;
using System.Windows.Controls;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for PopQuestion.xaml
    /// </summary>
    public partial class PopQuestion : UserControl
    {
        public PopQuestion()
        {
            InitializeComponent();
        }

        public string LeftBtnContent
        {
            get { return (string)GetValue(LeftBtnContentProperty); }
            set { SetValue(LeftBtnContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftBtnContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftBtnContentProperty =
            DependencyProperty.Register("LeftBtnContent", typeof(string), typeof(PopQuestion), new PropertyMetadata("?", OnLeftBtnContentChanged));

        public string RightBtnContent
        {
            get { return (string)GetValue(RightBtnContentProperty); }
            set { SetValue(RightBtnContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftBtnContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightBtnContentProperty =
            DependencyProperty.Register("RightBtnContent", typeof(string), typeof(PopQuestion), new PropertyMetadata("?", OnRightBtnContentChanged));



        public string MassageText
        {
            get { return (string)GetValue(MassageTextProperty); }
            set { SetValue(MassageTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QuestionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MassageTextProperty =
            DependencyProperty.Register("MassageText", typeof(string), typeof(PopQuestion), new PropertyMetadata("?", OnMassageTextChanged));

        private static void OnMassageTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PopQuestion popQuestion)
            {
                popQuestion.OnMassageTextChanged();
            }
        }

        private void OnMassageTextChanged()
        {
            text.Text = MassageText;
        }

        private static void OnRightBtnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PopQuestion popQuestion)
            {
                popQuestion.OnRightBtnContentChanged();
            }
        }

        private void OnRightBtnContentChanged()
        {
            btnRight.Content = RightBtnContent;
        }

        private static void OnLeftBtnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PopQuestion popQuestion)
            {
                popQuestion.OnLeftBtnContentChanged();
            }
        }

        private void OnLeftBtnContentChanged()
        {
            btnLeft.Content = LeftBtnContent;
        }
    }
}
