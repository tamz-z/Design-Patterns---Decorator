using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationApp
{
    // Client-class die als manager fungeert voor de notificaties.
    // De manager werkt alleen met de interface INotificationService en kent dus
    // niet de concrete services (Email, Sms, Push). Daardoor kan er later een
    // nieuwe service of een adapter worden toegevoegd zonder deze class of
    // Program.cs aan te passen.
    public class NotificationManager
    {
        private INotificationService _notificationService;

        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService
                ?? throw new ArgumentNullException(nameof(notificationService));
        }

        // Wisselt van notificatiekanaal terwijl het programma draait.
        public void SetNotificationService(INotificationService notificationService)
        {
            _notificationService = notificationService
                ?? throw new ArgumentNullException(nameof(notificationService));
        }

        // Verstuurt het bericht via het kanaal dat op dit moment is ingesteld.
        public void Send(string recipient, string message)
        {
            _notificationService.Send(recipient, message);
        }
    }
}
