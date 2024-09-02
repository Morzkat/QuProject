// See https://aka.ms/new-console-template for more information
using QuProject.Console;

// Example word stream
List<string> matrix = new List<string> { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
List<string> wordStream = new List<string> { "chill", "cold", "wind" };

var finder = new WordFinder(matrix);
var topWords = finder.Find(wordStream);
Console.WriteLine($"Top words: {string.Join(",", topWords)}");

