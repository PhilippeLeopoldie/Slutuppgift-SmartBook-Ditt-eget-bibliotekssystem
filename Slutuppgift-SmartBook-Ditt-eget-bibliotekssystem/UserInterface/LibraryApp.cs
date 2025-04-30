using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;
using static Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Library;
using static Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Ceed.Ceed;

using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.UserInterface;

public static class LibraryApp
{
    private static Library library = new Library();
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
                CeedBookList(library);
                $"The list has now {library.Books.Count} Books!".Log();
                break;
            case 2:
                var newBook = library.AddBook(GetBookFromUserInput());
                $"-Book: {newBook} \nCreated!".Log();
                break;
            case 3:
                "-----Remove a book-----".Log();
                if (library.Books.Count == 0) "No book registered yet.\n".Log();
                else
                {
                    "Enter the ISBN of the book to remove:".Log();
                    var isbn = Util.stringValidation(Console.ReadLine());
                    var removedBook = library.RemoveBook(isbn);
                    if (removedBook != null)
                    {
                        $"Book {removedBook} \nhas been removed!".Log();
                    }
                    else
                    {
                        "Book not found!".Log();
                    }
                }
                    
                break;
            case 4:
                library.DisplayBookList();
                break;
            case 5:
                "\n-----Search book by title or author------".Log();
                "Enter any title or author:".Log();
                var foundBooks = library.SearchBooksByTitleOrAuthor(Util.stringValidation(Console.ReadLine()));
                if (foundBooks.Count == 0)
                {
                    "No books found!\n".Log();
                }
                else
                {
                    foreach (var book in foundBooks)
                    {
                        $"{book}".Log();
                    }
                }
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

    private static Book GetBookFromUserInput()
    {
        var book = new Book();
        "-----Book registration----:".Log();
        "Enter book title:".Log();
        book.Title = Util.stringValidation(Console.ReadLine());
        "Enter book author:".Log();
        book.Author = Util.stringValidation(Console.ReadLine());
        "Choose a genre number among the following:".Log();
        library.displayGenres().Log();
        book.Genre = (GenreType)Util.intValidation(Console.ReadLine());
        return book;
    }


}
