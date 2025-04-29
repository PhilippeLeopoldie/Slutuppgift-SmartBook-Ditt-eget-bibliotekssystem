using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;
using static Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Library;
using static Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Ceed.Ceed;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.UserInterface;

public static class LibraryApp
{
    private static Dictionary<int, string> Menu = new Dictionary<int, string>
    {
        {1,"Ceed list of books" },
        {2,"Register a book" },
        {3,"Remove a book" },
        {4,"Display the list of books" },
        {5,"Search book by title or author" },
        {6,"Borrow a book" },
        {0,"Exit" }
    };

    internal static string StartPresentation()
    {
        "------- Main Menu -------".Log();
        "Choose a function :".Log();

        foreach (var option in Menu)
        {
            $"Enter {option.Key} to {option.Value}".Log();
        }
        return Console.ReadLine();
    }

    internal static void Run(int input)
    {
        switch(input)
        {
            case 1:
                CeedBookList();
                
                break;
            case 2:
                AddBook(new Book());
                break;
            case 3:
                "Remove a book".Log();
                break;
            case 4:
                DisplayBooks();
                break;
            case 5:
                SearchBooksByTitleOrAuthor();
                break;
            case 6:
                "Borrow a book".Log();
                break;
            case 7:
                
                break;
            case 0:
                "Exit".Log();
                break;
            default:
                "Invalid input, please try again.".ErrorMsg();
                break;
        }
    }


}
