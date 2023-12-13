using Project;

var restaurant = new Restaurant("Terjes Trivelige Tapas", 16, 20);

var table1 = restaurant.AddTable("A", 4);
var table2 = restaurant.AddTable("B", 6);

Console.WriteLine(table1.GetDescription());

var dateTime = new DateTime(2023, 12, 24, 17, 0, 0);

var reservationResponse1 = restaurant.CreateReservation("Olsen", "998 87 766", 5, dateTime);

// Console.WriteLine(reservationResponse1.GetDescription);
// -- Reservert bord til 5 personer 24.12.2023 kl. 17:00

// var reservationResponse2 = restaurant.CreateReservation("Hansen", "997 78 866", 5, dateTime);
// Console.WriteLine(reservationResponse2.GetDescription);
// -- Vi beklager! Det er ikke ledig bord til 5 personer 24.12.2023 kl. 17:00

//r reservationResponse1.Cancel();
