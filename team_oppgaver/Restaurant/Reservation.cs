namespace Project;

class Reservation
{
    private readonly string _name;
    private readonly string _phone;
    private readonly int _seats;
    private readonly DateTime _reservedTime;

    public string TableId { get; }

    public Reservation(string name, string phone, int seats, DateTime reservedAt, string tableId)
    {
        _name = name;
        _phone = phone;
        _seats = seats;
        _reservedTime = reservedAt;
        TableId = tableId;
    }

    public bool TimeOverlaps(DateTime dateTime) {
        return Math.Abs(dateTime.Ticks - _reservedTime.Ticks) < new TimeSpan(2, 0, 0).Ticks;
    }
}
