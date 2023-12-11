using Project;
using System;

var restaurant = new Restaurant {
	RestaurantName = "Terjes Trivelige Tapas",
	OpeningTime = 16,
	ClosingTime = 20,
};

var table1 = restaurant.AddTable("A", 4);
var table2 = restaurant.AddTable("B", 6);

Console.WriteLine(table1.GetDescription());

var time = DateTime.Now;

var reservationResponse1 = restaurant.TryCreateReservation("Olsen", "998 87 766", 5, time);
Console.WriteLine(reservationResponse1.Description);

var reservationResponse2 = restaurant.TryCreateReservation("Hansen", "997 78 866", 5, time);
Console.WriteLine(reservationResponse2.Description);