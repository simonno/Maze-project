﻿namespace MazeGUI.Settings
{
    public class SettingsViewModel : NotifyChanged
    {
        private ISettingsModel model;
        public SettingsViewModel(ISettingsModel model)
        {
            this.model = model;
        }
        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        public int ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        public int SearchAlgorithm
        {
            get { return model.SearchAlgorithm; }
            set
            {
                model.SearchAlgorithm = value;
                NotifyPropertyChanged("SearchAlgorithm");
            }
        }

        public void SaveSettings()
        {
            model.SaveSettings();
        }
        public void ReloadSettings()
        {
            model.ReloadSettings();
        }
    }
}