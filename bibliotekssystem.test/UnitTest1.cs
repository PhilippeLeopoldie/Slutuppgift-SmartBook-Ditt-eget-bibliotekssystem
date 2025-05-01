
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;

namespace bibliotekssystem.test;

public class UnitTest1
{


    [Fact]
    public void Should_Add_One_Book_In_The_List()
    {
        // Arrange
            var library = new Library();
            var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        // Act
            library.AddBook(book);
        // Assert
            Assert.Single(library.Books);
    }
    
    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    public void Should_Add_Multiple_Books_In_The_List(int numberOfBooks)
    {
        // Arrange, Act
        var library = new Library();
        for(int i = 0; i < numberOfBooks; i++)
        {
            var book = new Book { Title = $"Book {i + 1}", Author = $"Author {i + 1}", Genre = GenreType.SciFi };
            library.AddBook(book);
        }
    
        // Assert
        Assert.Equal(numberOfBooks, library.Books.Count);
    }

    [Fact]
    public void Should_Not_Add_Book_With_Duplicate_ISBN()
    {
        // Arrange
        var library = new Library();
        var book1 = new Book { Title = "Original", Isbn = "01234567890123", Author = "Author A", Genre = GenreType.Action };
        var book2 = new Book { Title = "Copy", Isbn = "01234567890123", Author = "Author B", Genre = GenreType.Drama };

        library.AddBook(book1);

        // Act
        var result = library.AddBook(book2);

        // Assert
        Assert.Null(result);
        Assert.Single(library.Books);
        Assert.Equal("Original", library.Books[0].Title);
    }


    [Fact]
    public void Should_Found_Book_By_Title()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);

        // Act
        var foundBook = library.SearchBooksByTitleOrAuthor("Starfall");

        // Assert
        Assert.NotNull(foundBook);
        Assert.Equal("Starfall", foundBook.FirstOrDefault()?.Title);
    }
    [Fact]
    public void Should_Found_Book_By_Author()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var foundBook = library.SearchBooksByTitleOrAuthor("Alyssa Grey");
        // Assert
        Assert.NotNull(foundBook);
        Assert.Equal("Alyssa Grey", foundBook.FirstOrDefault()?.Author);
    }

    [Fact]
    public void Should_Return_Book_When_SearchByISBN()
    {
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var result = library.SearchBookByIsbn(book.Isbn);
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Starfall", result.Title);
        Assert.Equal("Alyssa Grey", result.Author);
    }

    [Fact]
    public void Should_Return_Null_When_Search_With_WrongISBN()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var result = library.SearchBookByIsbn("wrongISBN");
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Should_Remove_Book_byISBN()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var removedBook = library.RemoveBookByISBN(book.Isbn);
        // Assert
        Assert.NotNull(removedBook);
        Assert.Equal("Starfall", removedBook.Title);
        Assert.Empty(library.Books);
    }

    [Theory]
    [InlineData("1234567890123")]
    [InlineData("9876543210987")]
    [InlineData("1234567890124")]
    public void Should_Return_Null_When_Wrong_ISBN(string isbn)
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var removedBook = library.RemoveBookByISBN(isbn);
        // Assert
        Assert.Null(removedBook);
    }

    [Fact]
    public void Should_Remove_Book_byTitle()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var removedBook = library.RemoveBookByTitle(book.Title);
        // Assert
        Assert.NotNull(removedBook);
        Assert.Equal("Starfall", removedBook.Title);
        Assert.Empty(library.Books);
    }

    [Theory]
    [InlineData("wrongTitle1")]
    [InlineData("wrongTitle2")]
    [InlineData("wrongTitle3")]
    public void Should_Return_Null_When_Wrong_Title(string title)
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var removedBook = library.RemoveBookByTitle(title);
        // Assert
        Assert.Null(removedBook);
    }
    [Fact]
    public void Should_Display_Genres()
    {
        // Arrange
        var library = new Library();
        // Act
        var genres = library.displayGenres();
        // Assert
        Assert.Contains("0.Action", genres);
        Assert.Contains("1.Adventure", genres);
        Assert.Contains("2.Comedy", genres);
        Assert.Contains("3.Drama", genres);
        Assert.Contains("4.Fantasy", genres);
    }
    [Fact]
    public void Should_Borrow_Book()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi };
        library.AddBook(book);
        // Act
        var borrowedBook = library.BorrowBook(book);
        // Assert
        Assert.NotNull(borrowedBook);
        Assert.Equal(AvailabilityType.Borrowed, borrowedBook.Availability);
    }
    
    [Fact]
    public void Should_Return_Null_When_Book_Not_Available()
    {
        // Arrange
        var library = new Library();
        var book = new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi, Availability = AvailabilityType.Borrowed };
        library.AddBook(book);
        // Act
        var borrowedBook = library.BorrowBook(book);
        // Assert
        Assert.Null(borrowedBook);
    }

    [Fact]
    public void Should_Save_LibraryToJson_And_CreatesValidJsonFile()
    {
        // Arrange
        var library = new Library();
        library.Books = new List<Book>
        {
            new Book { Title = "Test Book", Isbn = "123", Availability = AvailabilityType.Available }
        };

        string filePath = "test_library.json";

        // Act
        library.SaveLibraryToJson(filePath);

        // Assert
        Assert.True(File.Exists(filePath));
        string content = File.ReadAllText(filePath);
        Assert.Contains("Test Book", content);

        // Clean up
        File.Delete(filePath);
    }


    
}
