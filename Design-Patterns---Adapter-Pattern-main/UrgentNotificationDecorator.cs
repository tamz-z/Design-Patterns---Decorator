namespace NotificationApp
{
    public class UrgentNotificationDecorator
        : NotificationDecorator
    {
        public UrgentNotificationDecorator(
            INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(
            string recipient,
            string message)
        {
            // [URGENT] voor het bericht zetten en daarna doorsturen
            notificationService.Send(recipient, "[URGENT] " + message);
        }
    }
}
