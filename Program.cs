using System;
using System.Linq;

namespace DeutschDictionary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataFile = args.FirstOrDefault() ?? "de-test-words.tsv";

            var reader = new FileReader();

            var dictionary = reader.ReadDictionary("dict");
            var data = reader.ReadData(dataFile);
            var splitter = new Splitter(dictionary);

            foreach (var word in data)
            {
                Console.Write($"(in) {word} -> (out) ");
                var parts = splitter.SplitWord(word);
                if (parts.Any())
                    Console.WriteLine(string.Join("; ", parts.Select(x => $"({string.Join(", ", x)})")));
                else
                    Console.WriteLine($"({word})");
            }

            Console.ReadKey();
        }
    }
}