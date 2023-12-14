namespace Project;
internal class ReservationResponse {
	public string _description;
	public Reservation? _reservation;

	
	public ReservationResponse(string description, Reservation? reservation) {
		_description = description;
		_reservation = reservation;
	}

	public Reservation? GetReservation() => _reservation;
	public string GetDescription() => _description;
}
