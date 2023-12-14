namespace Project;

class Reservation
{
    public readonly string Name;
    public readonly string Phone;
    public readonly int Seats;
    public readonly DateTime ReservedAt;
    public string TableId { get; }

    public Reservation(string name, string phone, int seats, DateTime reservedAt, string tableId)
    {
        Name = name;
        Phone = phone;
        Seats = seats;
        ReservedAt = reservedAt;
        TableId = tableId;
    }

    public bool TimeOverlaps(DateTime dateTime) {
        return Math.Abs(dateTime.Ticks - ReservedAt.Ticks) < new TimeSpan(2, 0, 0).Ticks;
    }
}
