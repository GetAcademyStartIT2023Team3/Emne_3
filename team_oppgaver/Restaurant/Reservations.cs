namespace Project;

class Reservations
{
    private readonly string _name;
    private readonly string _phone;
    private readonly int _seats;
    private readonly DateTime _dateTime;
    public string TableId { get; }
    public Reservations(string name, string phone, int seats, DateTime dateTime, string tableId)
    {
        _name = name;
        _phone = phone;
        _seats = seats;
        _dateTime = dateTime;
        TableId = tableId;
    }
}