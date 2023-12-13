namespace Project;

internal class Restaurant {
    private readonly string _name;
    private readonly int _openingHour;
    private readonly int _closingHour;
    private List<Table> _tables = new();
    private List<Reservations> _reservations = new();

    public Restaurant(string name, int openingTime, int closingTime) {
        _name = name;
        _openingHour = openingTime;
        _closingHour = closingTime;
    }

	public Table AddTable(string id, int seats)
    {
        // TODO: check if table exist in List<Table> before adding
        var table = new Table(id, seats);
        _tables.Add(table);

        return table;
    }

    public Reservations CreateReservation(string name, string phone, int seats, DateTime dateTime)
    {
        // TODO: check if reservation is possible before returning Reservations

        // LINQ syntax to find unoccupied tables
        var possible_tables = _tables
            .Where(t => t.Seats >= seats)
			.Where(t => ! _reservations.Exists(r => r.TableId == t.Id));

        if (possible_tables == null) { /*handle null reference*/ };

        string tableId = "please give me a valid table id :)";
        var reservation = new Reservations(name, phone, seats, dateTime, tableId);
        _reservations.Add(reservation);
        return reservation;
    }
}
