using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public GenreType Genre { get; set; }
    public AvailabilityType Availability { get; set; }

}
