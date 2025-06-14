﻿using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;
using static Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Ceed.Seed;

using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.UserInterface;

public static class LibraryApp
{
    private static Library library = new Library();
    private static Dictionary<int, string> Menu = new Dictionary<int, string>
    {
        {1,"Seed list of books" },
        {2,"Register a book" },
        {3,"Remove a book by ISBN" },
        {4,"Remove a book by title" },
        {5,"Display the list of books" },
        {6,"Search book by title or author" },
        {7,"Borrow a book" },
        {8,"Save library into JSON file" },
        {9,"Load library from JSON file" },
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
                if (newBook == null) return;
                $"-Book: {newBook} \nCreated!".Log();
                break;
            case 3:
                "-----Remove a book by ISBN-----".Log();
                if (library.Books.Count == 0) "No book registered yet.\n".Log();
                else
                {
                    "Enter the ISBN (13 digits) of the book to remove:".Log();
                    var isbn = Util.stringValidation(Console.ReadLine());
                    var removedBook = library.RemoveBookByISBN(isbn);
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
                "-----Remove a book by Title-----".Log();
                if (library.Books.Count == 0) "No book registered yet.\n".Log();
                else
                {
                    "Enter the Title of the book to remove:".Log();
                    var title = Util.stringValidation(Console.ReadLine());
                    var removedBook = library.RemoveBookByTitle(title);
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
            case 5:
                library.DisplayBookList(library.Books);
                break;
            case 6:
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
            case 7:
                "------Borrow a book------".Log();
                if (library.Books.Count == 0) "No book registered yet.\n".Log();
                else
                {
                    "Enter any title or author:".Log();
                    var foundBooksToBorrow = library.SearchBooksByTitleOrAuthor(Util.stringValidation(Console.ReadLine()));
                    if (foundBooksToBorrow.Count == 0)
                    {
                        "No books found!\n".Log();
                        break;
                    }
                    else
                    {
                        foreach (var book in foundBooksToBorrow)
                        {
                            $"{book}".Log();
                        }
                        "\nEnter the ISBN (13 digits) of the book to borrow:".Log();
                        var isbn = Util.IsbnValidation(Console.ReadLine());
                        var bookToBorrow = library.SearchBookByIsbn(isbn);
                        while (bookToBorrow == null)
                        {
                            $"ISBN:{isbn} not found, please try again:".Log();
                            isbn = Util.IsbnValidation(Console.ReadLine());
                            bookToBorrow = library.SearchBookByIsbn(isbn);
                        }
                        ;
                        var result = library.BorrowBook(bookToBorrow);
                        if (result == null) break;
                        $"Book: {result} \nis now borrowed!".Log();
                    }
                }
                break;
            case 8:
                "-----Save library into JSON file-----".Log();
                "Enter file name:".Log();
                library.SaveLibraryToJson(Util.stringValidation(Console.ReadLine()));
                break;
            case 9:
                "-----Read library from JSON file-----".Log();
                "Enter file name:".Log();
                library.ReadLibraryFromJson(Util.stringValidation(Console.ReadLine()));
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
        "Enter book ISBN(13 digits):".Log();
        book.Isbn = Util.IsbnValidation(Console.ReadLine());
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
