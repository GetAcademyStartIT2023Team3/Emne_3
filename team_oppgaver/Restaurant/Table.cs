namespace Project;

class Table
{
    public string Id { get; }
    public int Seats { get; }

    public Table(string id, int seats)
    {
        Id = id;
        Seats = seats;
    }

    public string GetDescription()
    {
        return $"Bord {Id} har plass til {Seats} personer";
    }


}