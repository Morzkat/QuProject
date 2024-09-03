using QuProject.Console;

namespace QuProject.Test
{
    public class Tests
    {
        List<string> _matrix;
        WordFinder wordFinder;

        [SetUp]
        public void Setup()
        {
            _matrix = new List<string>() {
                "bcdccnzzck",
                "ijokwqffoc",
                "zzabqftnla",
                "chillssfdj",
                "woofsjascc",
                "tunasafast",
                "fzzzazzajp",
                "uzabjmoyue",
                "zzzubilzxe",
                "zgwiondqwj"
            };
            wordFinder = new WordFinder(_matrix);
        }

        [Test]
        public void FindHorizontalWords()
        {
            //Arrange
            var _wordStream = new List<string> { "woofs", "chill", "tunas", "jumbo" };
            var expected = new List<string> { "woofs", "chill", "tunas" };

            //Act
            var result = wordFinder.Find(_wordStream);

            //Assert
            var equal = expected.SequenceEqual(result);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]  
        public void FindInverserHorizontalWords()
        {
            //Arrange
            var _wordStream = new List<string> { "bazz", "buzz", "jazz", "jumbo" };
            var expected = new List<string> { "bazz", "buzz", "jazz" };

            //Act
            var result = wordFinder.Find(_wordStream);

            //Assert
            var equal = expected.SequenceEqual(result);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FindVerticalWords()
        {
            //Arrange
            var _wordStream = new List<string> { "jazmin", "banana", "jamb", "fuzz", "grill", "cold" };
            var expected = new List<string> { "jazmin", "fuzz", "cold"};

            //Act
            var result = wordFinder.Find(_wordStream);

            //Assert
            var equal = expected.SequenceEqual(result);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FindInverserVerticalWords()
        {
            //Arrange
            var _wordStream = new List<string> { "fast", "koji", "grill", "jeep" };
            var expected = new List<string> { "fast", "koji", "jeep" };

            //Act
            var result = wordFinder.Find(_wordStream);

            //Assert
            var equal = expected.SequenceEqual(result);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void OrderTopWordsByMostRepeated()
        {
            //Arrange
            var _wordStream = new List<string> { "jack", "koji", "grill", "fast", "jeep", "fast" };
            var expected = new List<string> { "fast", "jack", "koji", "jeep" };

            //Act
            var result = wordFinder.Find(_wordStream);

            //Assert
            var equal = expected.SequenceEqual(result);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}