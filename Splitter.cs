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
            var length = word.Length;
            var firstLength = 1;
            while (firstLength < length)
            {
                var part1 = word.Substring(0, firstLength);
                var part2 = word.Substring(firstLength, length - firstLength);

                if (_dictionary.Contains(part1) && _dictionary.Contains(part2))
                {
                    result.Add(part1);
                    result.Add(part2);
                }

                firstLength++;
            }
            if (!result.Any())
                result.Add(word);

            return result;
        }
    }
}