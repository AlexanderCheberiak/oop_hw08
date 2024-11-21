﻿using System;

//Код порушував принцип Single Responsibility.
//Для виправлення створив окремий інтерфейс та клас логера.

class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

// Інтерфейс для логування
interface ILogger
{
    void Log(string message);
}

// Логування через консоль
class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// Клас для відправки електронних листів
class EmailSender
{
    private readonly ILogger _logger;

    public EmailSender(ILogger logger)
    {
        _logger = logger;
    }

    public void Send(Email email)
    {
        _logger.Log($"Email from '{email.From}' to '{email.To}' was sent");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        ILogger logger = new ConsoleLogger();
        EmailSender emailSender = new EmailSender(logger);

        emailSender.Send(e1);
        emailSender.Send(e2);
        emailSender.Send(e3);
        emailSender.Send(e4);
        emailSender.Send(e5);
        emailSender.Send(e6);

        Console.ReadKey();
    }
}