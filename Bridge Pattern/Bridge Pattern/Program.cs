using System;

public interface INotification
{
    void Send(string message);
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Уведомление SMS   | {message}");
    }
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Уведомление Email | {message}");
    }
}

public abstract class NotificationService
{
    protected INotification notification;

    protected NotificationService(INotification notification)
    {
        this.notification = notification;
    }

    public abstract void Notify(string message);
}

public class SmsNotificationService : NotificationService
{
    public SmsNotificationService(INotification notification) : base(notification) { }

    public override void Notify(string message)
    {
        notification.Send($"письмо по СМС: {message}");
    }
}

public class EmailNotificationService : NotificationService
{
    public EmailNotificationService(INotification notification) : base(notification) { }

    public override void Notify(string message)
    {
        notification.Send($"письмо по Email: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotification emailNotification = new EmailNotification();
        NotificationService emailService = new EmailNotificationService(emailNotification);
        emailService.Notify("приветствую");
        emailService.Notify("как дела");

        INotification smsNotification = new SmsNotification();
        NotificationService smsService = new SmsNotificationService(smsNotification);
        smsService.Notify("здравствуйте, вас беспокоит менеджер");
        smsService.Notify("уделите время");
    }
}
