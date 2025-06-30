using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQWorkerConsumer;

public interface IMessageHandler<T> { Task HandleAsync(T message); }

public class RabbitConnectionOptions
{
    public required string HostName { get; set; } /// example "localhost"
    public int Port { get; set; } // example 5672
    public required string UserName { get; set; } // example "user"
    public required string Password { get; set; } // example "password"
    public required string QueueName { get; set; } // example "test.name"
}

public class WorkerConsumitor<T>
{
    private readonly IMessageHandler<T> _handler;
    private readonly RabbitConnectionOptions options;
    private readonly ConnectionFactory _factory;

    public WorkerConsumitor( IMessageHandler<T> handler, RabbitConnectionOptions options)
    {
        _handler = handler;
        this.options = options;
        _factory = new ConnectionFactory
        {
            HostName = this.options.HostName,
            UserName = this.options.UserName,
            Password = this.options.Password,
            Port = this.options.Port
        };
    }

    public async Task StartAsync()
    {
        using var connection = await _factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: options.QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            var message = JsonSerializer.Deserialize<T>(json);
            if (message is not null)
            {
                await _handler.HandleAsync(message);
                await channel.BasicAckAsync(ea.DeliveryTag, false);
            }
        };

        await channel.BasicConsumeAsync(queue: options.QueueName, autoAck: false, consumer: consumer);

        Console.WriteLine($"Waiting for the message");

        await Task.Delay(Timeout.Infinite);
    }
}