using System;

namespace ExternalWhatsAppLibrary
{
    // Aangekochte externe library. Broncode staat hier alleen ter illustratie;
    // in een echt project zou dit een gerefereerde DLL zijn die we niet aanpassen.
    public class WhatsAppClient
    {
        public void SendWhatsAppMessage(
            string phoneNumber,
            string text,
            bool urgent)
        {
            Console.WriteLine("EXTERNE WHATSAPP SERVICE");
            Console.WriteLine($"Telefoonnummer: {phoneNumber}");
            Console.WriteLine($"Tekst: {text}");
            Console.WriteLine($"Urgent: {urgent}");
        }
    }
}
