using QuProject.Console.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuProject.Console
{
    public class WordFinder
    {
        private readonly int _cols;
        private readonly int _rows;
        private IList<string> _matrix;
        private readonly HashSet<string> _matrixSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any()) throw new ArgumentException("Matrix cannot be null or empty.");

            _matrix = matrix.ToList();
            _rows = matrix.Count();
            _cols = matrix.First().Count();

            AddHorizontalWordsToMatrix();
            AddVerticallyWordsToMatrix();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var foundWords = new Dictionary<string, int>();

            foreach (var word in wordstream.Distinct())
            {
                if (_matrixSet.Contains(word, new WordsComparer()))
                {
                    if (!foundWords.ContainsKey(word))
                        foundWords[word] = 1;
                    else foundWords[word]++;
                }
            }

            var topWords = foundWords
                    .OrderByDescending(record => record.Value)
                    .Take(10)
                    .Select(record => record.Key);

            return topWords;
        }

        private void AddHorizontalWordsToMatrix()
        {
            foreach (var row in _matrix) _matrixSet.Add(row);
        }

        public void AddVerticallyWordsToMatrix()
        {
            var matrixList = _matrix.ToList();
            for (int i = 0; i < _cols; i++)
            {
                var word = "";
                for (int j = 0; j < _rows; j++) word += matrixList[j][i];

                _matrixSet.Add(word);
            }
        }

    }
}


