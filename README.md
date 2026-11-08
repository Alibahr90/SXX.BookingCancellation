# SXX BookingCancellation

Individuell examinationsuppgift i objektorienterad analys och design.

## Vald funktionalitet

**US-26 – Avboka en befintlig bokning**

Projektet är en C#-konsolapplikation som demonstrerar hur en kund kan avboka en bokning enligt verksamhetens regler.

Lösningen utgår från gruppens kravanalys och design för SXX Maskiner och Utrustning AB, men är en separat individuell implementation.

## Funktioner

- Hämta en bokning via boknings-ID.
- Kontrollera att bokningen tillhör kunden.
- Kontrollera att bokningen har status `Confirmed`.
- Kontrollera att avbokningsfristen inte har passerat.
- Ändra bokningens status till `Cancelled`.
- Spara avbokningen i ett repository som lagrar data i minnet.
- Hantera felaktiga avbokningsförsök.

## Verksamhetsregler

- **BR-10:** Avbokning frigör exemplaret för nya bokningar.
- **BR-11:** Påbörjad uthyrning får inte avbokas.
- **BR-15:** Kunden får avboka till dagen före bokningens startdatum.
- **BR-16:** Efter avbokningsfristen måste kunden kontakta personalen.

## Teknik

- C# och .NET
- Objektorienterad programmering
- Repository Pattern
- Dependency Injection via konstruktor
- PlantUML

Ingen databas eller externa tjänster används.

## Projektstruktur

```text
SXX.BookingCancellation/
├── Models/
│   ├── Booking.cs
│   └── BookingStatus.cs
├── Repositories/
│   ├── IBookingRepository.cs
│   └── InMemoryBookingRepository.cs
├── Services/
│   └── BookingService.cs
├── UML/
│   ├── Aktivitetsdiagram.puml
│   └── Sekvensdiagram.puml
└── Program.cs
```

## Körinstruktioner

1. Klona repositoryt eller ladda ner projektet från GitHub.
2. Öppna lösningen i Visual Studio.
3. Kontrollera att rätt .NET SDK är installerat.
4. Bygg projektet med `Ctrl + Shift + B`.
5. Kör programmet med `Ctrl + F5`.

## Verifiering

Tre scenarier har körts:

| Scenario | Resultat | Status efter |
|---|---|---|
| Lyckad avbokning | Success | Cancelled |
| För sen avbokning | TooLate | Confirmed |
| Misslyckat sparande | SaveFailed | Confirmed |

Samtliga tre scenarier gav förväntat resultat vid manuell körning.

## UML-diagram

I mappen `UML` finns:

- `Aktivitetsdiagram.puml` – beskriver huvudflöde och alternativa flöden.
- `Sekvensdiagram.puml` – beskriver hur Program, BookingService, Booking och IBookingRepository samverkar.

## Avgränsningar

Projektet omfattar endast avbokning av en befintlig bokning.

Följande ingår inte:

- Grafiskt gränssnitt
- Databas
- Inloggningssystem
- Skapa nya bokningar
- Betalning och fakturering

## Underlag

Projektet utgår från gruppens kravanalys, produktbacklog och UML-design för SXX Maskiner och Utrustning AB.

Den individuella implementationen är separat från gruppens projekt.
