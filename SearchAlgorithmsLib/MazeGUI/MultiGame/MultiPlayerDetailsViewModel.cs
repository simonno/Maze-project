using System;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace MazeGUI.MultiGame
{
    class MultiPlayerDetailsViewModel : NotifyChanged
    {
        private IMultiPlayerModel model;

        public MultiPlayerDetailsViewModel(IMultiPlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate(Object sender, PropertyChangedEventArgs e){
                MultiPlayer mp = new MultiPlayer(model);
                mp.Show();
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public ObservableCollection<string> GamesList
        {

            get
            {
                return new ObservableCollection<string>(model.GamesList);
            }

            set
            {
                NotifyPropertyChanged("GamesList");
            }

        }

        public int MazeRows
        {
            get { return Properties.Settings.Default.MazeRows; }
            set
            {
                NotifyPropertyChanged("MazeRows");
            }
        }

        public int MazeCols
        {
            get { return Properties.Settings.Default.MazeCols; }
            set
            {
                NotifyPropertyChanged("MazeCols");
            }
        }

        public void Start(string mazeName, int rows, int cols)
        {
            model.Start(mazeName, rows,  cols);
            
        }

        public void Join(string mazeName)
        {
        model.Join(mazeName);
        }
        
    }
}
