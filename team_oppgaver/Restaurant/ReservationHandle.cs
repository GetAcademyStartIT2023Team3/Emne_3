namespace Project;

class ReservationHandle
{
    public static List<Reservation> GetAllReservationsForDate(DateTime date, List<Reservation> reservations)
    {
        List<Reservation> res = new();

        foreach (Reservation r in reservations)
        {
            if (date.Day == r.ReservedAt.Day) res.Add(r);
        }

        return reservations;
    }
}
