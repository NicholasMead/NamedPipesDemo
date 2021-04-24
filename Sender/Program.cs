using System;

using Common;
using System.IO;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipe = PipeHelper.CreateClient(PipeNames.Sender);

            var writer = new StreamWriter(pipe);

            while (true)
            {
                Console.Write("Type your message: ");
                var message = Console.ReadLine();

                Console.WriteLine($"Sending: {message}");

                writer.WriteLine(message);
                writer.Flush();

                Console.WriteLine($"Message Sent!");
            }
        }
    }
}
