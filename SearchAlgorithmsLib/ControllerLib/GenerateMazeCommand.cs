using MazeLib;
using System;
using System.Net.Sockets;
using ModelLib;

namespace ControllerLib
{
    class GenerateMazeCommand : Command
    {
        public GenerateMazeCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = model.GenerateMaze(name, rows, cols);

            string a= maze.ToJSON();
            string afterConvert = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '\n')
                {
                    afterConvert += "@";
                }
                else
                {
                    afterConvert += a[i];
                }
                
            }return afterConvert;
        }
}