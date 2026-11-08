using SXX.BookingCancellation.Models;
using SXX.BookingCancellation.Repositories;

namespace SXX.BookingCancellation.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public string CancelBooking(Guid customerId, Guid bookingId)
    {
        Booking? booking = _bookingRepository.GetById(bookingId);

        if (booking is null || booking.CustomerId != customerId)
            return "NotFound";

        if (booking.Status != BookingStatus.Confirmed)
            return "Avbokning nekas";

        if (DateOnly.FromDateTime(DateTime.Today) >= booking.StartDate)
            return "TooLate";

        booking.Cancel();

        bool saved = _bookingRepository.UpdateBooking(booking);

        if (!saved)
            return "SaveFailed";

        return "Success";
    }
}