﻿using System;

class Controller
{
    private Dictionary<string, ICommand> commands;
    private IModel model;
    public Controller()
    {
        model = new Model();
        commands = new Dictionary<string, ICommand>();
        commands.Add("generate", new GenerateMazeCommand(model));
        // more commands...
    }
    public string ExecuteCommand(string commandLine, TcpClient client)
    {
        string[] arr = commandLine.Split(' ');
        string commandKey = arr[0];
        if (!commands.ContainsKey(commandKey))
            return "Command not found";
        string[] args = arr.Skip(1).ToArray();
        ICommand command = commands[commandKey];
        return command.Execute(args, client);
    }
}
