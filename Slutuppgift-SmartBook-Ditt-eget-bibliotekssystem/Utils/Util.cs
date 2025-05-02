
namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Utils;

public static class Util
{
    public static void Log(this string message)
    {
        Console.WriteLine(message);
    }

    public static string IsbnValidation(string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            "Input cannot be empty.".ErrorMsg();
            input = Console.ReadLine();
        }
        input.longValidation();
        while (input?.Length != 13 )
        {
            "ISBN must be 13 characters long.".ErrorMsg();
            input = Console.ReadLine();
        }
        return input;
    }

    public static string stringValidation(string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            "Input cannot be empty.".ErrorMsg();
            input = Console.ReadLine();
        }
        return input.ToLower();
    }

    public static int intValidation(this string input)
    {
        int result;
        while (!int.TryParse(input, out result) || result < 0)
        {
            Log("This is not a number, try again: ");
            input = Console.ReadLine();
        }
        ;
        return result;
    }

    public static long longValidation(this string input)
    {
        long result;
        while (!long.TryParse(input, out result) || result < 0)
        {
            Log("This is not a number, try again: ");
            input = Console.ReadLine();
        }
        ;
        return result;
    }

    public static void ErrorMsg(this string msg)
    {
        Log($"{new ArgumentException($"{msg}")}");
    }
}
