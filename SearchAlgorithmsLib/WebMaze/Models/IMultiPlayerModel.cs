using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    interface IMultiPlayerModel
    {

        /// <summary>
        /// Starts the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="host">The host.</param>
        void Start(string name, int rows, int cols);

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        List<string> List();

        /// <summary>
        /// Joins the specified player.
        /// </summary>
        /// <param name="name">The name - the maze.</param>
        /// <param name="guest">The guest the client.</param>
        /// <returns>the current maze</returns>
        Maze Join(string name);

    }
}
