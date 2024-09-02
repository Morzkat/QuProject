using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuProject.Console.Utils
{
    public class WordsComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) => x.Contains(y);

        public int GetHashCode(string obj) => obj.GetHashCode();
    }
}
