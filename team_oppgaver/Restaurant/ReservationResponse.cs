namespace Project;
internal class ReservationResponse {
	public string _description;
	public Reservations? _reservation;

	
	public ReservationResponse(string description, Reservations? reservation) {
		_description = description;
		_reservation = reservation;
	}

	public Reservations? GetReservation() => _reservation;
	public string GetDescription() => _description;
}
