namespace Project;

internal class Restaurant {
    private readonly string _name;
    private readonly int _openingHour;
    private readonly int _closingHour;
    private List<Table> _tables = new();
    private List<Reservation> _reservations = new();

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

    public ReservationResponse CreateReservation(string name, string phone, int seats, DateTime dateTime)
    {
        // LINQ syntax to find unoccupied tables
        Table? smallest_table = _tables
            .Where(t => t.Seats >= seats) // get all tables with >= seats
            .Where(t => !_reservations.Exists(r => r.TableId == t.Id && r.TimeOverlaps(dateTime))) // get all tables which do not have a reservation at specified time
            .OrderBy(t => t.Seats)
            .FirstOrDefault();
            
        if ( smallest_table == null) { /*handle null reference*/
            var description = $"Vi beklager! Det er ikke ledig bord til {seats} personer {dateTime}";
            return new ReservationResponse(description, null);
		};

        var reservation = new Reservation(name, phone, seats, dateTime, smallest_table.Id);
        _reservations.Add(reservation);

		return new ReservationResponse($"Reservert bord til {seats} personer {dateTime}", reservation);
    }
}

/*

hva kreves for å kunne reservere
1. antall seter -> finn bord med >= antall seter
2. tid og dato -> 


BORD:
    A: 6 seter
    B: 4 seter
    C: 5 seter

BESTILLING
    1:
        5 personer
        17:00
        Tldeles bord C
    2:
        5 personer
        17:00
        Tildeles bord A
    3:
        4 personer
        17:00
        Tildeles bord B
    4:
        4 personer
        17:00
        INGEN LEDIG


*/
