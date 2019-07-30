using System;
using System.Collections.Generic;
using System.Linq;

namespace DeutschDictionary
{
    public class Splitter
    {
        private readonly Dictionary _dictionary;

        public Splitter(Dictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public IEnumerable<string> SplitWord(string word)
        {
            var result = new List<string>();

            for (var length = 1; length < word.Length; length++)
            {
                var part1 = word.Substring(0, length);
                var part2 = word.Substring(length, word.Length - length);
                if (_dictionary.Contains(part1))
                {
                    var splitted = SplitWord(part2);

                    if (splitted.Any())
                    {
                        result.Add(part1);
                        result.AddRange(splitted);
                    }
                    if (_dictionary.Contains(part2))
                    {
                        result.Add(part1);
                        result.Add(part2);
                    }
                }
            }

            return result;
        }
    }
}