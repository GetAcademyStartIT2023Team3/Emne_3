namespace Project;

class Table
{
    private readonly string _tableID;
    private readonly int _seats;

    public Table(string tableID, int seats)
    {
        _tableID = tableID;
        _seats = seats;
    }

    public string GetDescription()
    {
        return $"Bord {_tableID} har plass til {_seats} personer.";
    }
}