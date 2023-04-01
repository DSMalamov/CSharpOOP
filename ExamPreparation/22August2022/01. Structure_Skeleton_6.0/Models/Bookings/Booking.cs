using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings;

public class Booking : IBooking
{
    private int residenceDuration;
    private int adultsCount;
    private int childrenCount;
    public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
    {
        Room = room;
        ResidenceDuration = residenceDuration;
        AdultsCount = adultsCount;
        ChildrenCount = childrenCount;
        BookingNumber = bookingNumber;

    }
    public IRoom Room { get; private set; }

    public int ResidenceDuration
    {
        get => residenceDuration;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
            }

            residenceDuration = value;
        }
    }

    public int AdultsCount
    {
        get => adultsCount;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
            }

            adultsCount = value;
        }
    }

    public int ChildrenCount
    {
        get => childrenCount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.ChildrenNegative);
            }

            childrenCount = value;
        }

    }

    public int BookingNumber { get; }

    public string BookingSummary()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Booking number: {BookingNumber}");
        sb.AppendLine($"Room type: {Room.GetType().Name}");
        sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
        sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");

        return sb.ToString().Trim();
    }

    private double TotalPaid()
    {
        return Math.Round(ResidenceDuration * Room.PricePerNight, 2);  
    }
}
