using System;
using Common;
using System.IO;
using System.IO.Pipes;

namespace Reciever
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipe = PipeHelper.CreateClient(PipeNames.Reciever);

            var reader = new StreamReader(pipe);

            while(true)
            {
                Console.Write("How many messages to recieve: ");

                var input = Console.ReadLine();
                
                if(!int.TryParse(input, out int messageCount))
                {
                    Console.Write("Thats not a number, dummy...");
                    continue;
                }

                for(var x = 0; x < messageCount; x++)
                {
                    var message = reader.ReadLine();
                    Console.WriteLine($"Message {x + 1}: {message}");
                }
            }

        }
    }
}
