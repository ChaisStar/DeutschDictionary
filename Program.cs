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
                var parts = splitter.SplitWord(word);
                Console.WriteLine($"(in) {word} -> (out) {(parts.Any() ? string.Join(", ", parts.Distinct()) : word)}");
            }

            Console.ReadKey();
        }
    }
}