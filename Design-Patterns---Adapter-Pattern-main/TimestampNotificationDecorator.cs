namespace NotificationApp
{
    public class TimestampNotificationDecorator
        : NotificationDecorator
    {
        public TimestampNotificationDecorator(
            INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(
            string recipient,
            string message)
        {
            // de tijd van nu voor het bericht zetten en daarna doorsturen
            string time = DateTime.Now.ToString("HH:mm");
            notificationService.Send(recipient, $"[{time}] {message}");
        }
    }
}
