using System.Diagnostics.Contracts;

public class Productum
{

    public string Name { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public int ProductumTypeId { get; set; }

    public DateTime DateStocked { get; set; }

    public int DaysOnShelf
    {
        get
        {
            TimeSpan timeOnShelf = DateTime.Now - DateStocked;
            return timeOnShelf.Days;
        }
    }
}
