using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    class MultiPlayerViewModel : NotifyChanged
    {

        private IMultiPlayerModel model;

        public MultiPlayerViewModel(IMultiPlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                MultiPlayer mp = new MultiPlayer(model);
                mp.Show();
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public void Play(Direction move)
        {
            model.Play(move);
        }
     

        public void Close()
        {
            model.Close(MazeName);
        }
        public Direction OpponentPosChanged
        {
            get { return Direction.Up; }
           
        }

        public string MazeToString
        {
            get
            {
                string maze = model.MazeToString;
                return maze.Replace(Environment.NewLine, "");
            }
        }

        public string MazeName
        {
            get
            {
                return model.MazeName;
            }
        }

        public int MazeRows
        {
            get
            {
                return model.MazeRows;
            }
        }
        public int MazeCols
        {
            get
            {
                return model.MazeCols;
            }
        }

    }
}
