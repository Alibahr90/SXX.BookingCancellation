using SXX.BookingCancellation.Models;

namespace SXX.BookingCancellation.Repositories;

public interface IBookingRepository
{
    Booking? GetById(Guid bookingId);

    bool UpdateBooking(Booking booking);
}