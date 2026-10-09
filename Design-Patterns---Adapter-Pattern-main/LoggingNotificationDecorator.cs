namespace NotificationApp
{
    public class LoggingNotificationDecorator
        : NotificationDecorator
    {
        public LoggingNotificationDecorator(
            INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(
            string recipient,
            string message)
        {
            // eerst loggen
            Console.WriteLine($"LOG: notificatie naar {recipient}");

            // daarna het versturen doorgeven aan notificationService
            notificationService.Send(recipient, message);
        }
    }
}
