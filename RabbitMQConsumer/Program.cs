using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQConsumer.Db;
using System;
using System.Text;

namespace RabbitMQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (DbPostgresContext context = new DbPostgresContext())
            //{
                var connectionFactory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
                using (var connection = connectionFactory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("Queue", false, false, false, null);
                        var reader = new EventingBasicConsumer(channel);
                        reader.Received += (m, e) =>
                        {
                            var body = e.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);                           
                            Console.WriteLine($"Queue üzerinden gelen mesaj: {message} ");
                        };
                        channel.BasicConsume(queue: "Queue",
                                         autoAck: true, //mesaj otamatik olarak kuyruktan silinir.
                                         consumer: reader);
                    }
                }
            //}
        }
    }
}
