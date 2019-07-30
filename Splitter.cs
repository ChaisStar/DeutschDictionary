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

        public IEnumerable<IEnumerable<string>> SplitWord(string word)
        {
            var result = new List<List<string>>();

            for (var length = 1; length < word.Length; length++)
            {
                var part1 = word.Substring(0, length);
                var part2 = word.Substring(length, word.Length - length);
                if (_dictionary.Contains(part1))
                {
                    var splitted = SplitWord(part2);

                    if (splitted.Any())
                    {
                        foreach (var item in splitted)
                        {
                            var list = new List<string> { part1 };
                            list.AddRange(item);
                            result.Add(list);
                        }
                    }
                    if (_dictionary.Contains(part2))
                    {
                        result.Add(new List<string> { part1, part2 });
                    }
                }
            }

            return result;
        }
    }
}