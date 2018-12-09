using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISvc.Utils
{
    class RabbitMQUtils
    {
        public static void sendMSG(String vendingCode, String message)
        {
            String enpoint = Environment.GetEnvironmentVariable("RabbitMQ_HOST");
            Int32 port = Int32.Parse(Environment.GetEnvironmentVariable("RabbitMQ_PORT"));
            String user = Environment.GetEnvironmentVariable("RabbitMQ_User");
            String pass = Environment.GetEnvironmentVariable("RabbitMQ_Pass");
            String echange = Environment.GetEnvironmentVariable("RabbitMQ_EXCHANGE");
            String vHost = Environment.GetEnvironmentVariable("RabbitMQ_VHOST");
            Console.WriteLine("start send message: " + DateTime.Now);
            var connectionFactory = new ConnectionFactory();
            connectionFactory.Endpoint = new AmqpTcpEndpoint(enpoint, port);
            connectionFactory.VirtualHost = vHost;
            connectionFactory.UserName = user;
            connectionFactory.Password = pass;
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(vendingCode, false, false, false, null);
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(echange, vendingCode, null, bytes);
            channel.Close();
            connection.Close();
            Console.WriteLine("end send message: " + DateTime.Now);
        }
    }
}
