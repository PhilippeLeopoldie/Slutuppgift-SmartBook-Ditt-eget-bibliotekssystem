
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
        Assert.Equal("Starfall", foundBook.FirstOrDefault().Title);
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
        Assert.Equal("Alyssa Grey", foundBook.FirstOrDefault().Author);
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
}
