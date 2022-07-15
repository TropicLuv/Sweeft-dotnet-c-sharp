using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using System.IO;

namespace Tasks.src
{
    internal class Exercises_Sweeft

    {

        bool isPalindrome(string text)
        {
            if (text.Length < 2)
                return true;

            if (text[0] == text[text.Length - 1])
                return isPalindrome(text.Substring(1, text.LastIndexOf(text[text.Length - 1]) - 1));

            return false;
        }

        int MinSplit(int amount)
        {
            int coins = 0;
            while (amount > 0)
            {
                coins++;
                if (amount >= 50)
                    amount -= 50;
                else if (amount >= 20)
                    amount -= 20;
                else if (amount >= 10)
                    amount -= 10;
                else if (amount >= 5)
                    amount -= 5;
                else
                    amount -= 1;
            }
            return coins;
        }

        int NotContains(int[] array)
        {
            Integer num = new Integer();
            var arrOfNumbers = Enumerable.ToArray(array.Where(x => x > 0).ToHashSet().Where(x => x == num.inc()));
            return arrOfNumbers.Length == 0 ? 1 : arrOfNumbers[arrOfNumbers.Length - 1] + 1;
        }

        bool isProperly(string sequence)
        {
            if (sequence.Length % 2 != 0) return false;
            int k = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (k < 0) return false;
                if (sequence[i] == '(') k++;
                else k--;
            }
            return (k == 0) ? true : false;
        }

        static private int fact(int n)
        {
            return n == 0 ? 1 : n * fact(n - 1);
        }
        static int CountVariants(int stairCount)
        {
            if (stairCount < 0) return -1;
            int returnValue = 0, twoStairs = 0;
            while (twoStairs <= stairCount)
            {
                returnValue += (fact(stairCount) / ((fact(twoStairs)) * (fact(stairCount-- - twoStairs++))));
            }
            return returnValue;
        }

        void GenerateCountryFiles()
        {
            var path = @"W:\C#\Tasks\Tasks\src\Countries\";
            string jsonData = (new WebClient()).DownloadString("https://restcountries.com/v3.1/all");
            Country[] countries = JsonConvert.DeserializeObject<Country[]>(jsonData);
            foreach (Country country in countries)
            {
                string myPath = path + country.Name.Common + ".txt";
                FileStream file = File.Create(myPath);
                var info = new UTF8Encoding(true).GetBytes(country.Region + "\n" + country.Subregion + "\n" + country.Latlng[0] +"," + country.Latlng[1] + "\n" + country.Area + "\n" + country.Population);
                file.Write(info, 0, info.Length);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine();
            var a = new Exercises_Sweeft();
            Console.WriteLine("__________isPalindrome_____________");
            Console.WriteLine("isPalindrome Test 1 -> (\"hello_SWEEFT!\") : " + a.isPalindrome("hello_SWEEFT!"));
            Console.WriteLine("isPalindrome Test 2 -> (\"olo1olo\") : " + a.isPalindrome("olo1olo"));
            Console.WriteLine("isPalindrome Test 3 -> (\"a\") : " + a.isPalindrome("a"));
            Console.WriteLine("isPalindrome Test 4 -> (\"\") : " + a.isPalindrome(""));

            Console.WriteLine("__________MinSplit_____________");
            Console.WriteLine("MinSplit Test 1 -> (99) : " + a.MinSplit(99));
            Console.WriteLine("MinSplit Test 2 -> (100) : " + a.MinSplit(100));

            Console.WriteLine("__________notContains_____________");
            Console.WriteLine("NotContains Test 1 -> ({1,2,3}) : " + a.NotContains(new int[] { 1, 2, 3 }));
            Console.WriteLine("NotContains Test 2 -> ({-1,2,3}) : " + a.NotContains(new int[] { -1, 2, 3 }));
            Console.WriteLine("NotContains Test 3 -> ({1,2,3,4,5,6,8}) : " + a.NotContains(new int[] { 1, 2, 3, 4, 5, 6, 8 }));

            Console.WriteLine("__________isProperly_____________");
            Console.WriteLine("isProperly Test 1 -> \"()(())\" : " + a.isProperly("()(())"));
            Console.WriteLine("isProperly Test 2 -> \")()(\" : " + a.isProperly(")()("));

            Console.WriteLine("____________________________________");
            a.GenerateCountryFiles();
        }




    }
}


