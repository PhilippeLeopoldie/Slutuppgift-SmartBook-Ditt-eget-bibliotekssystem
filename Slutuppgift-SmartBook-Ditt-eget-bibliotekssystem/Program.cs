using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;
using Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.UserInterface;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem;

internal class Program
{
    static void Main(string[] args)
    {

        try
        {
            var stopProgram = 0;
            var input = 0;
            do
            {
                input = Util.intValidation(LibraryApp.StartPresentation());
                LibraryApp.Run(input);
            }
            while (input != stopProgram);
        }
        catch (Exception e)
        {
            e.Message.Log();
        }
    }
}
