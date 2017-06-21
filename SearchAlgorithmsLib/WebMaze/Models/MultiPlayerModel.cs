using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;

namespace WebMaze.Models
{
    public class MultiPlayerModel : IMultiPlayerModel
    {

        /// <summary>
        /// Joins the specified name.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="guest">The guest client.</param>
        /// <returns the maze></returns>
        /// <exception cref="Exception">This maze does not exist - " + name</exception>
        public Maze Join(string name)
        {
            //if (!multiPlayerWaiting.ContainsKey(name))
            //{
            //    throw new Exception("This maze does not exist - " + name);
            //}
            //MultiPlayerInfo mp = multiPlayerWaiting[name];
            //mp.Guest = guest;
            //multiPlayerOnline[name] = mp;
            //multiPlayerWaiting.Remove(name);
            //return mp.Maze;
            throw new Exception();

        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>list of all the online maze now client can join</returns>
        public List<string> List()
        {
            //Dictionary<string, MultiPlayerInfo>.KeyCollection namesCollaction = multiPlayerWaiting.Keys;
            //string[] temp = new string[namesCollaction.Count];
            //namesCollaction.CopyTo(temp, 0);
            //return new List<string>(temp);
            throw new Exception();
        }


        /// <summary>
        /// Starts the specified of maze.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="rows">The rows of maze.</param>
        /// <param name="cols">The cols of maze.</param>
        /// <param name="host">The host of maze.</param>
        public void Start(string name, int rows, int cols)
        {
            //Maze maze = Generate(name, rows, cols);
            //MultiPlayerInfo mp = new MultiPlayerInfo()
            //{
            //    Host = host,
            //    Maze = maze
            //};
            //multiPlayerWaiting.Add(name, mp);
        }


        /// <summary>
        /// Generates the specified maze.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="rows">The rows of maze.</param>
        /// <param name="cols">The cols of maze.</param>
        /// <returns></returns>
        private Maze Generate(string name, int rows, int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            maze.Name = name;
            return maze;
        }
    }
}