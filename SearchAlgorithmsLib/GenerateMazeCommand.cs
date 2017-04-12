﻿using System;


class GenerateMazeCommand : ICommand
{
    private IModel model;
    public GenerateMazeCommand(IModel model)
    {
        this.model = model;
    }
    public string Execute(string[] args, TcpClient client)
    {
        string name = args[0];
        int rows = int.Parse(args[1]);
        int cols = int.Parse(args[2]);
        Maze maze = model.GenerateMaze(name, rows, cols);
        return maze.ToJSON();
    }
}