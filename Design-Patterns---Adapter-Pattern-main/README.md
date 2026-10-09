# Antwoorden Decorator Pattern

## Opdracht 1

1. Omdat de variabele van het type INotificationService is. EmailNotificationService en SmsNotificationService implementeren allebei deze interface, dus ze passen allebei in die variabele.
2. INotificationService.
3. `Send(string recipient, string message)`
4. Je kunt makkelijk wisselen tussen email en sms zonder de rest van de code aan te passen. De code die Send aanroept hoeft niet te weten welke service het precies is.
## Opdracht 4

1. 8 classes: 4 voor email en 4 voor sms.
2. Dan verdubbelt het aantal classes. Van elke class die er al is moet ook een versie met timestamp komen. Dan heb je 16 classes.
3. TimestampEmail, LoggedTimestampEmail, UrgentTimestampEmail en LoggedUrgentTimestampEmail. En dezelfde vier voor sms.
4. Nee. Het werkt wel, maar je krijgt veel te veel classes.
5. Voor elke combinatie heb je een nieuwe class nodig. Dit heet class explosion. Ook staat dezelfde code (bijvoorbeeld de logregel) in heel veel classes. Als je iets aan het loggen wilt veranderen, moet je dat in al die classes doen.

## Opdracht 5

1. Zodat je een decorator overal kunt gebruiken waar een INotificationService nodig is. Voor de rest van de code is het gewoon een notificatieservice. Zo kun je een decorator ook weer in een andere decorator stoppen.
2. In dat field zit het object dat de decorator inpakt. Na zijn eigen extra stap geeft de decorator het versturen door aan dat object.
3. Met EmailNotificationService kan de decorator alleen email inpakken. Met INotificationService kan hij alles inpakken: email, sms, push en ook een andere decorator.
4. IS-A: de decorator is zelf een INotificationService, want hij implementeert de interface. HAS-A: de decorator heeft een INotificationService in zich, namelijk het object in het field dat hij inpakt.

## Opdracht 6

Nee, ik hoefde LoggingNotificationDecorator niet aan te passen. De decorator werkt met INotificationService en niet met een vaste class. Daarom maakt het niet uit of er een EmailNotificationService of een SmsNotificationService in zit.

## Opdracht 8

```
Program
   ↓
LoggingNotificationDecorator
   ↓
UrgentNotificationDecorator
   ↓
EmailNotificationService
```

1. De Send() van LoggingNotificationDecorator, want dat is het buitenste object.
2. Daarna de Send() van UrgentNotificationDecorator.
3. EmailNotificationService.
4. Omdat een decorator zelf ook een INotificationService is. Het field in de decorator is van het type INotificationService, dus daar past ook een andere decorator in.

## Opdracht 9

1. Gedaan, zie Program.cs. Allebei de varianten geven deze uitvoer:

```
LOG: notificatie naar student@school.nl
EMAIL
Aan: student@school.nl
Bericht: [URGENT] Je rooster is gewijzigd.
```

2. Variant A:

```
Program
   ↓
LoggingNotificationDecorator
   ↓
UrgentNotificationDecorator
   ↓
EmailNotificationService
```

Variant B:

```
Program
   ↓
UrgentNotificationDecorator
   ↓
LoggingNotificationDecorator
   ↓
EmailNotificationService
```

3. Nee. Bij A wordt eerst gelogd en daarna komt [URGENT] voor het bericht. Bij B komt eerst [URGENT] voor het bericht en daarna wordt er gelogd.
4. Ja. Bij deze twee varianten is de uitvoer toevallig hetzelfde, maar dat komt alleen doordat de logregel het bericht niet laat zien.
5. Elke decorator geeft het bericht door aan het object dat erin zit. Een decorator ziet dus alleen wat de decorators erbuiten al veranderd hebben. Als de logregel ook het bericht zou laten zien, dan zie je bij A het bericht zonder [URGENT] en bij B met [URGENT]. Bij Urgent en Timestamp zie je het meteen: Timestamp → Urgent → Email geeft "[URGENT] [14:33] ...", maar Urgent → Timestamp → Email geeft "[14:33] [URGENT] ...".

## Opdracht 11

1. Dat weet je niet als je alleen de aanroep ziet. Je moet eerst in de methode kijken welke parameter wat is.
2. Dan komen er steeds meer parameters bij, bijvoorbeeld `Send(recipient, message, true, true, false, false, true, false)`. Je moet dan ook elke aanroep aanpassen en de methode krijgt steeds meer if-statements.
3. De class met de Send-methode, dus EmailNotificationService en SmsNotificationService. Die moeten dan alles zelf doen: versturen, loggen, urgent, timestamp, encryptie, retry en audit logging.
4. c. Het hangt af van de situatie, maar meestal vind ik decorators overzichtelijker.
5. Als je maar één simpele optie hebt, is een parameter prima. Maar als je veel extra's hebt die je wilt combineren, zijn decorators beter. Elke decorator doet maar één ding, je ziet in de code welke decorators eromheen zitten, en je hoeft de bestaande classes niet aan te passen als er iets nieuws bijkomt.

## Pattern Detective

- Situatie A: Adapter
- Situatie B: Facade
- Situatie C: Decorator
- Situatie D: Adapter
- Situatie E: Decorator

## Adapter, Facade en Decorator

| Pattern | Welk probleem lost het op? | Korte onthoudzin |
|---|---|---|
| Adapter | Een class of library past niet bij de interface die jouw code verwacht. De adapter vertaalt de aanroep naar iets wat wel past. | Adapter maakt iets passend. |
| Facade | Een systeem met veel classes en stappen is lastig om te gebruiken. De facade geeft één simpele methode die alles in de goede volgorde doet. | Facade maakt iets makkelijker. |
| Decorator | Je wilt extra gedrag toevoegen en combineren, zonder de class aan te passen en zonder voor elke combinatie een subclass te maken. | Decorator breidt iets uit door het in te pakken. |

## Eindopdracht

Code (staat ook in Program.cs):

```csharp
INotificationService notification =
    new LoggingNotificationDecorator(
        new TimestampNotificationDecorator(
            new UrgentNotificationDecorator(
                new SmsNotificationService()
            )
        )
    );

notification.Send("0612345678", "Je toets is verplaatst naar morgen.");
```

Schema:

```
LoggingNotificationDecorator
   ↓
TimestampNotificationDecorator
   ↓
UrgentNotificationDecorator
   ↓
SmsNotificationService
```

Uitvoer:

```
LOG: notificatie naar 0612345678
SMS
Aan: 0612345678
Bericht: [URGENT] [14:33] Je toets is verplaatst naar morgen.
```
