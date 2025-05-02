using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Isbn;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn  = new Isbn13().GenerateIsbn13();
    
    
    public GenreType Genre { get; set; }
    public AvailabilityType Availability { get; set; } = AvailabilityType.Available;


    public override string ToString()
    {
        var isbn13 = new Isbn13();
        return $"ISBN:{isbn13.GetIsbn13Format(Isbn)}, Title:{Title}, Author:{Author}, Genre:{Genre}, Availability:{Availability}";
    }
}
