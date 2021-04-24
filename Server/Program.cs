using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;

using Common;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server...");

            var inServer = new NamedPipeServerStream(PipeNames.Sender);
            var outServer = new NamedPipeServerStream(PipeNames.Reciever);

            new [] { inServer, outServer }
                .ToList()
                .ForEach(s => s.WaitForConnection());

            Console.WriteLine("Server Stated");

            var reader = new StreamReader(inServer);
            var writer = new StreamWriter(outServer);

            while (true)
            {
                Console.WriteLine($"Ready to revieve message");

                var line = reader.ReadLine();

                if (line == null)
                {
                    //Null is pipe closes
                    Environment.Exit(0);
                }

                Console.WriteLine($"Processing Message: {line}");

                try
                {
                    writer.WriteLine(line);
                    writer.Flush();
                    Console.WriteLine($"Message Sent!");
                }
                catch (IOException)
                {
                    Console.WriteLine($"Message Failed!");
                }
            }
        }
    }
}
