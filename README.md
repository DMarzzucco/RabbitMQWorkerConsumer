# RabbitMQWorkerConsumer

**RabbitMQWorkerConsumer** is a lightweight library designed to simplify the creation of message consumers in .NET applications using RabbitMQ.

This package encapsulates the logic for connecting, configuring, and consuming messages from a queue, allowing the developer to focus solely on defining the message and managing it through a simple interface.

It is specifically designed to avoid code repetition and facilitate the integration of RabbitMQ into your services, following good practices of asynchrony and decoupling.

## ✅ Main Features:

- Asynchronous connection to RabbitMQ using RabbitMQ.Client.
- Automatic queue declaration.
- Message consumption with explicit acknowledgment (acknowledgement).
- Automatic deserialization of JSON messages.
- `IMessageHandler<T>` interface for custom handling of each message type.

## 🚀 Quick Use:
You just need to:

- Define a message type (T).
- Implement `MessageHandler<T>` to process it.
- Provide the connection options (RabbitConnectionOptions).

## Example in a Console App:
```cs
using RabbitWorkerCore;

public class ClassMessage
{
    public required string Name { get; set; } = "Ivan";
}

public class NameVerificationHandler : IMessageHandler<ClassMessage>
{
    public Task HandleAsync(ClassMessage message)
    {
        Console.WriteLine($"This is a message for {message.Name} ");
        return Task.CompletedTask;
    }
}

class Program
{
    static async Task Main(string[] arg)
    {
        var options = new RabbitConnectionOptions
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "user",
            Password = "password",
            QueueName = "test-name"
        };
        var handler = new NameVerificationHandler();
        var worker = new WorkerConsumitor<ClassMessage>(handler, options);

        await worker.StartAsync();
    }
}
```

## Author:
**Dario Marzzucco**