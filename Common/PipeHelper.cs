using System;
using System.IO;
using System.IO.Pipes;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class PipeHelper
    {
        public static NamedPipeClientStream CreateClient(string name)
        {
            var client = new NamedPipeClientStream(name);

            var connectionAtempts = 0;

            while (!client.IsConnected)
            {
                try
                {
                    Console.WriteLine($"Connecting...");
                    client.Connect(1000);
                    Console.WriteLine($"Connected!");
                }
                catch (IOException)
                {
                    if (++connectionAtempts < 10)
                    {
                        Console.WriteLine($"Failed to connect, retry: {connectionAtempts}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to connect, exiting...");
                        Environment.Exit(1);
                    }
                }
            }
            
            return client;
        }

    }
}
