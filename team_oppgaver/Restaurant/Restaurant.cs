﻿using System.Text;

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

        StringBuilder stringOutput = new();
        StringBuilder header = new();
        StringBuilder headerRowDivide = new();

        stringOutput.Append($"{_name} | Reservasjoner for {date:dd.MMMM yyyy}\n");

        header.Append($"{"| Bord", -9}|");
        headerRowDivide.Append("|".PadRight(9, '=') + '|');

        foreach (var table in _tables)
        {
            header.Append($" {table.Id}: {table.Seats} {"Seter", -24}|");
            headerRowDivide.Append($"".PadRight(30, '=') + '|');
        }
        stringOutput.Append($"{headerRowDivide}\n{header}\n{headerRowDivide}");

        var currentTime = new DateTime(date.Year, date.Month, date.Day, _openingHour, 0, 0);
        var closingTime = new DateTime(date.Year, date.Month, date.Day, _closingHour, 0, 0);
        while (currentTime < closingTime)
        {
            StringBuilder row = new();

            foreach (var table in _tables)
            {
                StringBuilder columns = new();
                foreach (var reservation in reservations)
                {
                    if (table.Id != reservation.TableId) continue;

                    TimeSpan reservationOffset = currentTime - reservation.ReservedAt;

                    string column = reservationOffset.TotalHours switch
                    {
                        0.00 => $"-----------{reservation.ReservedAt:HH:mm}--------------",
                        0.25 => $"  Navn. {reservation.Name}",
                        0.75 => $"  Antall. {reservation.Seats} Personer",
                        1.25 => $"  Tlf. {reservation.Phone}",
                        1.75 => "vvvvvvvvvvvvvvvvvvvvvvvvvvvvvv",
                        _ => string.Empty,
                    };

                    columns.Append(column);
                }

                row.Append($"{columns,-30}|");
            }

            stringOutput.Append($"\n| {currentTime,-7:HH:mm}|{row}");
            currentTime = currentTime.AddMinutes(15);
        }

        return $"{stringOutput}\n{headerRowDivide}";
	}
}
