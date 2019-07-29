using System;
using System.Collections.Generic;
using System.Linq;

namespace DeutschDictionary
{
    public class Dictionary
    {
        private readonly IDictionary<int, IEnumerable<string>> _dictionary;

        public Dictionary(IEnumerable<string> dictionary)
        {
            _dictionary = dictionary
                .Select(x => x.ToLower())
                .GroupBy(x => x.Length)
                .ToDictionary(x => x.Key, x => x.AsEnumerable());
        }

        public bool Contains(string word)
        {
            if (!_dictionary.ContainsKey(word.Length))
                return false;

            return _dictionary[word.Length].Contains(word);
        }
    }
}