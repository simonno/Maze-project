using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject
{
    class ProgramClient
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 8000);
            client.Connect();
            // Wait for the writing and reading tasks to finish.
            while (client.ReadingTaskRunning || client.WritingTaskRunning) { }
            client.Close();
        }
    }
}
