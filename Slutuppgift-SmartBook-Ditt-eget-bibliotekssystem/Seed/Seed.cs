using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Enums;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Ceed;

internal static class Seed
{
    public static void CeedBookList(Library library)
    {
        library.Books.AddRange(
            new Book { Title = "Starfall", Author = "Alyssa Grey", Genre = GenreType.SciFi },
            new Book { Title = "The Last Note", Author = "Miles Carter", Genre = GenreType.Mystery },
            new Book { Title = "Ash and Flame", Author = "Lena Storm", Genre = GenreType.Fantasy },
            new Book { Title = "Silent Orbit", Author = "Noah Vance", Genre = GenreType.SciFi },
            new Book { Title = "Echoes of Guilt", Author = "Rachel Morn", Genre = GenreType.Mystery },
            new Book { Title = "The Iron Crown", Author = "Tessa Black", Genre = GenreType.Fantasy },
            new Book { Title = "Nova's Edge", Author = "Isaac Reed", Genre = GenreType.SciFi },
            new Book { Title = "The Vanishing Room", Author = "Emma Vale", Genre = GenreType.Mystery },
            new Book { Title = "Realmwalker", Author = "Kai Lennox", Genre = GenreType.Fantasy }
        );
       
    }
}
