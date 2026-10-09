namespace NotificationApp
{
    public class LoggedEmailNotificationService : EmailNotificationService
    {
        public override void Send(string recipient, string message)
        {
            Console.WriteLine("LOG: notificatie wordt verstuurd");
            base.Send(recipient, message);
        }
    }
}
