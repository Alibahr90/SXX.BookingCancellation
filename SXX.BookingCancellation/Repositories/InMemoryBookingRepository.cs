using SXX.BookingCancellation.Models;

namespace SXX.BookingCancellation.Repositories;

public class InMemoryBookingRepository : IBookingRepository
{
    private readonly Dictionary<Guid, Booking> _bookings = new();

    public bool SimulateSaveFailure { get; set; }

    public void Add(Booking booking)
    {
        _bookings[booking.Id] = booking.Copy();
    }

    public Booking? GetById(Guid bookingId)
    {
        if (_bookings.TryGetValue(bookingId, out Booking? booking))
            return booking.Copy();

        return null;
    }

    public bool UpdateBooking(Booking booking)
    {
        if (SimulateSaveFailure)
            return false;

        if (!_bookings.ContainsKey(booking.Id))
            return false;

        _bookings[booking.Id] = booking.Copy();

        return true;
    }
}