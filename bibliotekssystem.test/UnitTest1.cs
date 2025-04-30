
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
}
