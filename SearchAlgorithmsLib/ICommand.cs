using System;

public class Class1
{
    interface ICommand
    {
        string Execute(string[] args, TcpClient client = null);
    }
}
