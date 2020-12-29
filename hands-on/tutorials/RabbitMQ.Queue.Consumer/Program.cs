using System;
using RabbitMQ.Queue.Messages;

namespace RabbitMQ.Queue.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // keep link
            var messageType = typeof(SampleMessage);
            
            var config = ConfigHelper.GetAppSettingsConfig();
            using var consumer = new Consumer<SampleMessage>(config);
            consumer.MessageReceived += message =>
            {
                Console.WriteLine("You received message ----------------------------- ");
                Console.WriteLine(message.ToString());
            };
            consumer.Start();

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();

            consumer.Stop();
        }
    }
}