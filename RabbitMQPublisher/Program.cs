using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQPublisher.Db;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace RabbitMQPublisher
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (DbEntities db = new DbEntities())
            {
                var connectionFactory = new ConnectionFactory { HostName = "localhost" };
                using (var connection = connectionFactory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("Queue", false, false, false, null);
                        var customers = db.Customer.ToList();                        
                        var message = JsonConvert.SerializeObject(customers);
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: "",
                            routingKey: "Queue",
                            basicProperties: null,
                            body: body);

                        Console.WriteLine($"'Queue üzerine {message}' yazıldı.");
                        Thread.Sleep(300);
                    }
                }

            }
        }
    }
}
