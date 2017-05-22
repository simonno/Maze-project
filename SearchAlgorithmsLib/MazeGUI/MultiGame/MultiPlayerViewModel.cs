﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    class MultiPlayerViewModel : ViewModel
    {
        private ApplicationMultiPlayerModel model;

        public MultiPlayerViewModel(ApplicationMultiPlayerModel model)
        {
            this.model = model;
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