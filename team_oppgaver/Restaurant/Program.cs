using Project;

var restaurant = new Restaurant("Terjes Trivelige Tapas", 16, 20);

var table1 = restaurant.AddTable("A", 4);
var table2 = restaurant.AddTable("B", 6);

Console.WriteLine(table1.GetDescription());

var dateTime = new DateTime(2023, 12, 24, 17, 0, 0);

var reservationResponse1 = restaurant.CreateReservation("Olsen", "998 87 766", 5, dateTime);
// Console.WriteLine(reservationResponse1.Description);

// var reservationResponse2 = restaurant.CreateReservation("Hansen", "997 78 866", 5, time);
// Console.WriteLine(reservationResponse2.Description);


//Her
//var reservation1 = restaurant.CreateReservation("Olsen", "998 87 766", 4, dateTime);
//var reservation2 = restaurant.CreateReservation("Larsen", "998 86 766", 4, dateTime);

//reservation1.cancel();

//var reservation3 = restaurant.CreateReservation("Haugen", "998 85 766", 6, dateTime);
