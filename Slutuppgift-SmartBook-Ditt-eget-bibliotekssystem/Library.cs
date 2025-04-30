using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;
using System.Reflection.Metadata.Ecma335;
namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;

public class Library
{
    public  List<Book> Books { get; set; } = new List<Book>();

    public  Book AddBook(Book book)
    {
        if (Books.Any(b => b.Isbn == book.Isbn))
        {
            $"ISBN: {book.Isbn} already exists.\n".Log();
            return null;
        }
        Books.Add(book);
        return book;
    }

    public Book RemoveBookByISBN(string isbn)
    {
        var bookToRemove = Books.FirstOrDefault(book => book.Isbn == isbn);
        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            return bookToRemove;
        }
        else
        {
            return null;
        }
    }

    public Book RemoveBookByTitle(string title)
    {
        var bookToRemove = Books.FirstOrDefault(book => book.Title == title);
        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            return bookToRemove;
        }
        else
        {
            return null;
        }
    }

    public string displayGenres()
    {
        var genres = Enum
            .GetValues(typeof(GenreType))
            .Cast<GenreType>()
            .Select( genre => $"{(int)genre}.{genre}");
        return string.Join(", ", genres);
    }

    public  void DisplayBookList()
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

    public List<Book> SearchBooksByTitleOrAuthor(string input)
    {
        if (Books.Count == 0)
        {
            "\nThe list of books is empty!".Log();
            return new List<Book>();
        }
        else
        {
            return Books
                .Where(book => book.Title
                .Contains(input, StringComparison.OrdinalIgnoreCase)
            ||
                book.Author
                .Contains(input, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
