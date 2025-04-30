using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Isbn
{
    public class Isbn13
    {
        readonly string[] prefixes = { "978", "979" };
        public string Prefix { get; set; } 
        public int Group { get; set; }
        public int Publisher { get; set; }
        public int Title { get; set; }
        public int CheckDigit { get; set; }


        public string GenerateIsbn13()
        {
            Random random = new Random();
            Prefix = prefixes[random.Next(0, prefixes.Length)];//3 digits
            Group = random.Next(0, 10);//1 digit
            Publisher = random.Next(0, 10000);//4 digits
            Title = random.Next(0, 10000);//4 digits
            CheckDigit = random.Next(0, 10);//1 digits
            return $"{Prefix}{Group}{Publisher:D4}{Title:D4}{CheckDigit}";
        }

        public string GetIsbn13Format(string input)
        {
            Prefix = input.Substring(0, 3);
            Group = int.Parse(input.Substring(3, 1));
            Publisher = int.Parse(input.Substring(4, 4));
            Title = int.Parse(input.Substring(8, 4));
            CheckDigit = int.Parse(input.Substring(12, 1));
            return $"{Prefix}-{Group}-{Publisher:D4}-{Title:D4}-{CheckDigit}";
        }
    }
}
