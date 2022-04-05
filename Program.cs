using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW13._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "Text1.txt";
            string text = null;
            using (var sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
                text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            }

            List<string> words = text.Split(' ', '\n', '\r').ToList();
            words.RemoveAll(c => c == "");

            var dictionary = new Dictionary<string, int>();

            foreach (var item in words)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary.Add(item, 0);
                }
            }

            dictionary = dictionary.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value);

            int counter = 0;

            foreach (var item in dictionary)
            {
                if (counter == 10)
                    break;

                Console.WriteLine($"{counter + 1}. Слово: {item.Key} Встречается раз: {item.Value}");
                counter++;
            }
        }
    }
}
