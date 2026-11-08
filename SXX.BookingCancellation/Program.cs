using SXX.BookingCancellation.Models;
using SXX.BookingCancellation.Repositories;
using SXX.BookingCancellation.Services;

var customerId = Guid.NewGuid();

var repository = new InMemoryBookingRepository();
var service = new BookingService(repository);

// SCENARIO 1 - Lyckad avbokning

var booking1 = new Booking(
    Guid.NewGuid(),
    customerId,
    DateOnly.FromDateTime(DateTime.Today.AddDays(5))
);

repository.Add(booking1);

Console.WriteLine("SCENARIO 1 - Avbokning lyckas");
Console.WriteLine($"Status före: {repository.GetById(booking1.Id)?.Status}");

string result1 = service.CancelBooking(customerId, booking1.Id);

Console.WriteLine($"Resultat: {result1}");
Console.WriteLine($"Status efter: {repository.GetById(booking1.Id)?.Status}");

Console.WriteLine();

// SCENARIO 2 - För sent att avboka

var booking2 = new Booking(
    Guid.NewGuid(),
    customerId,
    DateOnly.FromDateTime(DateTime.Today)
);

repository.Add(booking2);

Console.WriteLine("SCENARIO 2 - Avbokning för sent");
Console.WriteLine($"Status före: {repository.GetById(booking2.Id)?.Status}");

string result2 = service.CancelBooking(customerId, booking2.Id);

Console.WriteLine($"Resultat: {result2}");
Console.WriteLine($"Status efter: {repository.GetById(booking2.Id)?.Status}");

Console.WriteLine();

// SCENARIO 3 - Sparandet misslyckas

var booking3 = new Booking(
    Guid.NewGuid(),
    customerId,
    DateOnly.FromDateTime(DateTime.Today.AddDays(7))
);

repository.Add(booking3);

repository.SimulateSaveFailure = true;

Console.WriteLine("SCENARIO 3 - Sparandet misslyckas");
Console.WriteLine($"Status före: {repository.GetById(booking3.Id)?.Status}");

string result3 = service.CancelBooking(customerId, booking3.Id);

Console.WriteLine($"Resultat: {result3}");
Console.WriteLine($"Status efter: {repository.GetById(booking3.Id)?.Status}");

repository.SimulateSaveFailure = false;

Console.WriteLine();
Console.WriteLine("Tryck på valfri tangent för att avsluta...");
Console.ReadKey();