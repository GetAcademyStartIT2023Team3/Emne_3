using static Project.Restaurant;

namespace Project;

internal class Restaurant {
	// Objektvariabler
	// "Init" betyr at de bare kan settes 1 gang når Restaurant blir initialisert
	// Dette lar deg sette det som new Restaurant { RestaurantName = "...", OpeningTime = ..... }
	public required string RestaurantName { get; init; }
	public required int OpeningTime { get; init; }
	public required int ClosingTime { get; init; }

	private readonly List<Reservation> Reservations = new();
	private readonly List<Table> Tables = new();

	//Typer
	//Record betyr at alle variablene i () er public required { get; init; }
	public record Reservation(string CustomerName, string PhoneNumber, int GuestCount, DateTime Time, string TableId);
	// ? betyr nullable eller optional
	public record ReservationResponse(string Description, Reservation? Reservation);
	public record Table(string TableId, int Capacity) {
		public string GetDescription() {
			return $"Bord {TableId} har plass til {Capacity} personer.";
		}
	};


	public Table AddTable(string TableId, int Capacity) {
		var table = new Table(TableId, Capacity);
		Tables.Add(table);
		return table;
	}

	//Kaller funksjonen "try" fordi det blir tydligere at det ikke er garantert at man får en reservasjon
	public ReservationResponse TryCreateReservation(string CustomerName, string PhoneNumber, int GuestCount, DateTime Time) {
		foreach(var table in Tables) {
			if(table.Capacity >= GuestCount) {
				//Linq Any returner true/false basert på lambdaen
				if(Reservations.Any(r => r.TableId == table.TableId && r.Time == Time)) break; //Dum måte å sjekke "time" - burde sjekke antall timer
				var res = new Reservation(CustomerName, PhoneNumber, GuestCount, Time, table.TableId);
				Reservations.Add(res);
				return new ReservationResponse("Reservert bord til x personer...", res);
			}
		}	
		return new ReservationResponse("Det er ikke ledige bord!", null);
	}
}