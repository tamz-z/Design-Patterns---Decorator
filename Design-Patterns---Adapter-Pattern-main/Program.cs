namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Opdracht 1
            Console.WriteLine("--- Opdracht 1 ---");
            INotificationService notification =
                new EmailNotificationService();

            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            // Opdracht 2: logging met inheritance
            Console.WriteLine("--- Opdracht 2 ---");
            notification = new LoggedEmailNotificationService();
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            notification = new LoggedSmsNotificationService();
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Opdracht 3: urgent met inheritance
            Console.WriteLine("--- Opdracht 3 ---");
            notification = new UrgentEmailNotificationService();
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            notification = new UrgentSmsNotificationService();
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Opdracht 6: logging decorator met email en met sms
            Console.WriteLine("--- Opdracht 6 ---");
            notification = new EmailNotificationService();
            notification = new LoggingNotificationDecorator(notification);
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            notification = new SmsNotificationService();
            notification = new LoggingNotificationDecorator(notification);
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Opdracht 7: urgent decorator
            Console.WriteLine("--- Opdracht 7 ---");
            notification =
                new UrgentNotificationDecorator(
                    new EmailNotificationService()
                );
            notification.Send("student@school.nl", "Je leslokaal is gewijzigd.");

            // Opdracht 8 en 9: variant A
            Console.WriteLine("--- Opdracht 9 variant A ---");
            notification =
                new LoggingNotificationDecorator(
                    new UrgentNotificationDecorator(
                        new EmailNotificationService()
                    )
                );
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            // Opdracht 9: variant B
            Console.WriteLine("--- Opdracht 9 variant B ---");
            notification =
                new UrgentNotificationDecorator(
                    new LoggingNotificationDecorator(
                        new EmailNotificationService()
                    )
                );
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            // Opdracht 10: Logging -> Timestamp -> Urgent -> Email
            Console.WriteLine("--- Opdracht 10 email ---");
            notification =
                new LoggingNotificationDecorator(
                    new TimestampNotificationDecorator(
                        new UrgentNotificationDecorator(
                            new EmailNotificationService()
                        )
                    )
                );
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            // Opdracht 10: dezelfde decorators met sms
            Console.WriteLine("--- Opdracht 10 sms ---");
            notification =
                new LoggingNotificationDecorator(
                    new TimestampNotificationDecorator(
                        new UrgentNotificationDecorator(
                            new SmsNotificationService()
                        )
                    )
                );
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Eindopdracht: sms, urgent, timestamp en gelogd
            Console.WriteLine("--- Eindopdracht ---");
            notification =
                new LoggingNotificationDecorator(
                    new TimestampNotificationDecorator(
                        new UrgentNotificationDecorator(
                            new SmsNotificationService()
                        )
                    )
                );
            notification.Send("0612345678", "Je toets is verplaatst naar morgen.");

            Console.ReadLine();
        }
    }
}
