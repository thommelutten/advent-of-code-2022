using Utils;

namespace Day3.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
        [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
        [TestCase("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV", "vPwwTWBwg")]
        public void TestSplitIntoCompartments(string input, string result1, string result2)
        {
            var output = RucksackRecognizer.SplitIntoCompartments(input);
            Assert.That(output.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(output[0], Is.EqualTo(result1));
                Assert.That(output[1], Is.EqualTo(result2));
            });
        }

        [TestCase("vJrwpWtwJgWr", "hcsFMMfFFhFp", 'p')]
        [TestCase("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", 'L')]
        [TestCase("PmmdzqPrV", "vPwwTWBwg", 'P')]
        public void TestFindSharedItems(string compartment1, string compartment2, char result)
        {
            var output = RucksackRecognizer.FindSharedItems(compartment1, compartment2);
            Assert.That(output.Count, Is.EqualTo(1));
            Assert.That(output[0], Is.EqualTo(result));
        }

        [TestCase('a', 1)]
        [TestCase('z', 26)]
        [TestCase('A', 27)]
        [TestCase('Z', 52)]
        public void TestCalculatePriorityScore(char item, int result)
        {
            var output = RucksackRecognizer.CalculatePriorityScore(item);
            Assert.That(output, Is.EqualTo(result));
        }

        [Test]
        public void TestFirstSmall()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var totalScore = RucksackRecognizer.CalculateTotalPriorityScore(lines);
            Assert.That(totalScore, Is.EqualTo(157));
        }

        [Test]
        public void TestFirstBig()
        {
            var lines = ReadFile.ReadLines("test-big.txt");
            var totalScore = RucksackRecognizer.CalculateTotalPriorityScore(lines);
            Console.WriteLine(totalScore);
        }

        [Test]
        public void TestSplitIntoElfGroups()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var groups = RucksackRecognizer.SplitIntoElfGroups(lines);
            Assert.That(groups.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestFindBadge()
        {
            var group = new List<string>
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg"
            };

            var badge = RucksackRecognizer.FindBadge(group);
            Assert.That(badge, Is.EqualTo('r'));

            var group2 = new List<string>
            {
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
            };

            badge = RucksackRecognizer.FindBadge(group2);
            Assert.That(badge, Is.EqualTo('Z'));
        }

        [Test]
        public void TestSecondSmall()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var totalScore = RucksackRecognizer.FindBadgeScores(lines);
            Assert.That(totalScore, Is.EqualTo(70));
        }

        [Test]
        public void TestSecondBig()
        {
            var lines = ReadFile.ReadLines("test-big.txt");
            var totalScore = RucksackRecognizer.FindBadgeScores(lines);
            Console.WriteLine(totalScore);
        }
    }
}