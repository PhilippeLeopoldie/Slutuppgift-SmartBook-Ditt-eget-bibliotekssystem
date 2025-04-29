using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift_SmartBook_Ditt_eget_bibliotekssystem.Isbn
{
    public class IsbnGenerator
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
            Prefix = prefixes[random.Next(0, prefixes.Length)];
            Group = random.Next(0, 1000);
            Publisher = random.Next(0, 10000);
            Title = random.Next(0, 100000);
            CheckDigit = random.Next(0, 10);
            return $"{Prefix}-{Group}-{Publisher:D4}-{Title:D4}-{CheckDigit}";
        }
    }
}
