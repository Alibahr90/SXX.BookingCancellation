namespace SXX.BookingCancellation.Models;

public class Booking
{
    public Guid Id { get; }
    public Guid CustomerId { get; }
    public DateOnly StartDate { get; }
    public BookingStatus Status { get; private set; }

    public Booking(Guid id, Guid customerId, DateOnly startDate)
    {
        Id = id;
        CustomerId = customerId;
        StartDate = startDate;
        Status = BookingStatus.Confirmed;
    }

    public bool Cancel()
    {
        if (Status != BookingStatus.Confirmed)
            return false;

        Status = BookingStatus.Cancelled;
        return true;
    }

    public Booking Copy()
    {
        return new Booking(Id, CustomerId, StartDate)
        {
            Status = this.Status
        };
    }
}