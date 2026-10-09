namespace NotificationApp
{
    public class LoggedSmsNotificationService : SmsNotificationService
    {
        public override void Send(string recipient, string message)
        {
            Console.WriteLine("LOG: notificatie wordt verstuurd");
            base.Send(recipient, message);
        }
    }
}
