using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;
using System.Reflection.Metadata.Ecma335;
namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;

public static class Library
{
    public static List<Book> Books { get; set; } = new List<Book>();

    public static void AddBook(Book book)
    {
        "-----Book registration----:".Log();
        "Enter book title:".Log();
        book.Title = Util.stringValidation(Console.ReadLine());
        "Enter book author:".Log();
        book.Author = Util.stringValidation(Console.ReadLine());
        "Choose a genre number among the following:".Log();
        displayGenres().Log();
        book.Genre = (GenreType)Util.intValidation(Console.ReadLine());
        Books.Add(book);
    }

    private static string displayGenres()
    {
        var genres = Enum
            .GetValues(typeof(GenreType))
            .Cast<GenreType>()
            .Select( genre => $" {(int)genre}.{genre}");
        return string.Join(',', genres);
    }

    public static void DisplayBooks()
    {
        "-----Books list-----".Log();
        if (Books.Count == 0)
        {
            "No books registered yet.\n".Log();
        }
        else 
        {
            Books
            .OrderBy(book => book.Title)
            .ToList()
            .ForEach(book => $"{book}\n".Log());
        }
    }

    public static void SearchBooksByTitleOrAuthor()
    {
        if (Books.Count == 0)
        {
            "The list of books is empty.\n".Log();
        }
        else
        {
            "Enter book title:".Log();
            var input = Util.stringValidation(Console.ReadLine());

            var booksByTitleOrAuthor = Books
                .Where(book => book.Title
                .Contains(input, StringComparison.OrdinalIgnoreCase)
            ||
                book.Author
                .Contains(input, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (booksByTitleOrAuthor.Count == 0)
            {
                "No books found.\n".Log();
            }
            else
            {
                foreach (var book in booksByTitleOrAuthor)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}
