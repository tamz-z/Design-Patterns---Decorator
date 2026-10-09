using System;
using ExternalWhatsAppLibrary;

namespace NotificationApp
{
    // Adapter: implementeert onze eigen INotificationService (Target) en
    // bevat een WhatsAppClient (Adaptee). Vertaalt Send(recipient, message)
    // naar SendWhatsAppMessage(phoneNumber, text, urgent), zodat de
    // NotificationManager WhatsApp kan gebruiken zonder dat WhatsAppClient
    // of INotificationService hoeven te veranderen.
    public class WhatsAppNotificationAdapter : INotificationService
    {
        private readonly WhatsAppClient _whatsAppClient;

        public WhatsAppNotificationAdapter(WhatsAppClient whatsAppClient)
        {
            _whatsAppClient = whatsAppClient
                ?? throw new ArgumentNullException(nameof(whatsAppClient));
        }

        public void Send(string recipient, string message)
        {
            _whatsAppClient.SendWhatsAppMessage(recipient, message, urgent: false);
        }
    }
}
