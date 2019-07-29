using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DeutschDictionary
{
    public class FileReader
    {
        public Dictionary ReadDictionary(string path)
        {
            return new Dictionary(ReadFile(path));
        }

        public IEnumerable<string> ReadData(string path)
        {
            return ReadFile(path)
                .Skip(1)
                .Select(x => x.Split('\t')[1]);
        }

        private IEnumerable<string> ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new ArgumentException($"File with {nameof(path)}: {path} not found");

            return File.ReadAllLines(path, Encoding.UTF8);
        }
    }
}