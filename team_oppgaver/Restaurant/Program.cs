using Project;

var restaurant = new Restaurant("Terjes Trivelige Tapas", 15, 21);

var table1 = restaurant.AddTable("A", 6);
var table2 = restaurant.AddTable("B", 3);
var table3 = restaurant.AddTable("C", 5);
var table4 = restaurant.AddTable("D", 4);

Console.WriteLine(table1.GetDescription());
Console.WriteLine(table2.GetDescription());
Console.WriteLine(table3.GetDescription());
Console.WriteLine(table4.GetDescription());

Console.WriteLine("\n++++++++++++++++++++++++++++++++++\n");

var dateTime1 = new DateTime(2023, 12, 24, 17, 0, 0);
var reservationResponse1 = restaurant.CreateReservation("Olsen", "998 87 766", 5, dateTime1);
Console.WriteLine(reservationResponse1.GetDescription());

var dateTime2 = new DateTime(2023, 12, 24, 15, 00, 0);
var reservationResponse2 = restaurant.CreateReservation("Jensen", "991 78 866", 5, dateTime2);
Console.WriteLine(reservationResponse2.GetDescription());

var dateTime3 = new DateTime(2023, 12, 24, 19, 00, 0);
var reservationResponse3 = restaurant.CreateReservation("Hansen", "447 28 226", 4, dateTime3);
Console.WriteLine(reservationResponse3.GetDescription());

var dateTime4 = new DateTime(2023, 12, 24, 14, 00, 0);
var reservationResponse4 = restaurant.CreateReservation("Hansen", "447 28 226", 4, dateTime4);
Console.WriteLine(reservationResponse4.GetDescription());

Console.WriteLine("\n++++++++++++++++++++++++++++++++++\n");

string res = restaurant.GetAllReservationsForDate(dateTime1);
Console.WriteLine(res);

// Bonus?
// Her er et scenario hvor jeg tenker det kunne vært lurt hvis reservasjons systemet
// Kunne flytte på hvilket bord man fikk dersom et bord blir reservert

// var reservation1 = restaurant.CreateReservation("Olsen", "998 87 766", 4, dateTime);
// var reservation2 = restaurant.CreateReservation("Larsen", "998 86 766", 4, dateTime);

// reservation1.cancel();

// var reservation3 = restaurant.CreateReservation("Haugen", "998 85 766", 6, dateTime);
