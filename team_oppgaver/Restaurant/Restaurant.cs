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
        if(dateTime.Hour < _openingHour || dateTime.Hour > _closingHour + 2) return new ReservationResponse("Utenfor åpningstider", null);
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

    public string GetAllReservationsForDate(DateTime date)
    {
        var reservations = ReservationHandle.GetAllReservationsForDate(date, _reservations);

        string printRows = $"Reservasjoner for {date.ToString("dd.MMMM yyyy")}\n\n";

        printRows += "Tid.".PadRight(6) + '|';
        foreach (var table in _tables)
        {
            printRows += $"    Bord {table.Id} ({table.Seats} personer)".PadRight(30) + '|';
        }

        var currentTime = new DateTime(date.Year, date.Month, date.Day, _openingHour, 0, 0);
        var closingTime = new DateTime(date.Year, date.Month, date.Day, _closingHour, 0, 0);
        while (currentTime < closingTime)
        {
            string row = "\n" + currentTime.ToString("HH:mm").PadRight(6) + "|";

            foreach (var table in _tables)
            {
                string col = String.Empty;
                foreach (var reservation in reservations)
                {
                    if (table.Id != reservation.TableId) continue;

                    string resTime = reservation.ReservedAt.ToString("HH:mm");

                    if (currentTime.ToString("HH:mm") == resTime)
                    {
                        col += $"-----------{resTime}--------------";
                    }
                    else if (currentTime.AddHours(-0.25).ToString("HH:mm") == resTime)
                    {
                        col += $"  Navn. {reservation.Name}";
                    }
                    else if (currentTime.AddHours(-0.75).ToString("HH:mm") == resTime)
                    {
                        col += $"  Antall. {reservation.Seats} Personer";
                    }
                    else if (currentTime.AddHours(-1.25).ToString("HH:mm") == resTime)
                    {
                        col += $"  Tlf. {reservation.Phone}";
                    }
                    else if (currentTime.AddHours(-1.75).ToString("HH:mm") == resTime)
                    {
                        col += "------------------------------";
                    }
                }

                row += col.PadRight(30) + '|';
            }

            printRows += row;
            currentTime = currentTime.AddMinutes(15);
        }

        return printRows;
	}
}
