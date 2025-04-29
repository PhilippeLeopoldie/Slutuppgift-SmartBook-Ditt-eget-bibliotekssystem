using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Isbn;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; } = new IsbnGenerator().GenerateIsbn13();
    


    /*public string Title {
        get => title; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                "Title cannot be empty.".ErrorMsg();
            }
            title = value;
        } 
    }*/
    /*public string Author { 
        get => author;
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                "Author cannot be empty.".ErrorMsg();
            }
            author = value;
        } 
    }*/
    
    public GenreType Genre { get; set; }
    public AvailabilityType Availability { get; set; } = AvailabilityType.Available;


    public override string ToString()
    {
        return $"ISBN:{Isbn}, Title:{Title}, Author:{Author}, Genre:{Genre}, Availability:{Availability}";
    }

}
