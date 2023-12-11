Skriv ferdig.
- del opp i klasser
- kapsle inn
- ha metodene i de klassene de hører hjemme. 

```java
// Info: En bordreservasjon er på 2 timer

var restaurant = new Restaurant("Terjes Trivelige Tapas", 16, 20);

var tableA = restaurant.AddTable("A", 6);
var tableB = restaurant.AddTable("B", 4);
Console.WriteLine(tableA.GetDescription());
// Bord A har plass til 6 personer

var dateTime = new DateTime(2023, 12, 24, 17, 0, 0);

var reservationResponse1 = restaurant.CreateReservation("Olsen", "998 87 766", 5, dateTime);
Console.WriteLine(reservationResponse1.GetDescription());
// Reservert bord til 5 personer 24.12.2023 kl. 17:00

var reservation1 = reservationResponse1.GetReservation();
Console.WriteLine(reservation1.GetDescription());
// Reservert bord til 5 personer 24.12.2023 kl. 17:00

var reservationResponse2 = restaurant.CreateReservation("Hansen", "997 78 866", 5, dateTime);
Console.WriteLine(reservationResponse2.GetDescription());
// Vi beklager! Det er ikke ledig bord til 5 personer 24.12.2023 kl. 17:00

var reservation2 = reservationResponse2.GetReservation();
// Denne skal være null

restaurant.CreateReservation("Nilsen", "994 48 866", 4, dateTime);

var txt = restaurant.GetAllReservationsForOneDay(dateTime.Date);
Console.WriteLine(txt);
//           Bord A (6 personer)     |     Bord B (4 personer)   
// 16:00                             |
// 16:15                             |
// 16:30                             |
// 16:45                             |
// 17:00  -----------------------    |   -----------------------
// 17:15   Olsen                     |    Nilsen
// 17:30                             |
// 17:45   5 personer                |    4 personer
// 18:00                             |
// 18:15   Tlf 998 87 766            |    Tlf 994 48 866
// 18:30                             |
// 18:45  -----------------------    |   -----------------------
// 19:00                             |
// 19:15                             | 
// 19:30                             |
// 19:45                             |
```
