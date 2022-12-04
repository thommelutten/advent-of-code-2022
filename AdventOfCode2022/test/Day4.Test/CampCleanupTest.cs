using Utils;

namespace Day4.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoadSections()
        {
            string elfPairSections = "2-4,6-8";

            var sections = CampCleanup.LoadSections(elfPairSections);
            Assert.That(sections[0].Item1, Is.EqualTo(2));
            Assert.That(sections[0].Item2, Is.EqualTo(4));
            Assert.That(sections[1].Item1, Is.EqualTo(6));
            Assert.That(sections[1].Item2, Is.EqualTo(8));
        }

        [TestCase(2, 4, 6, 8, false)]
        [TestCase(2, 8, 3, 7, true)]
        [TestCase(2, 3, 4, 5, false)]
        [TestCase(2, 6, 4, 8, false)]
        [TestCase(6, 6, 4, 6, true)]
        public void TestOneSectionFullyContainsAnother(int elf1Start, int elf1End, int elf2Start, int elf2End, bool result)
        {
            var elf1 = new Tuple<int, int>(elf1Start, elf1End);
            var elf2 = new Tuple<int, int>(elf2Start, elf2End);

            var fullyContained = CampCleanup.OneSectionFullyContainsAnother(elf1, elf2);
            Assert.That(fullyContained, Is.EqualTo(result));
        }

        [TestCase]
        public void TestFirstSmall()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var fullyContainedPairs = CampCleanup.CountFullyContainedPairs(lines);
            Assert.That(fullyContainedPairs, Is.EqualTo(2));
        }

        [TestCase]
        public void TestFirstBig()
        {
            var lines = ReadFile.ReadLines("test-big.txt");
            var fullyContainedPairs = CampCleanup.CountFullyContainedPairs(lines);
            Console.WriteLine(fullyContainedPairs);
        }

        [TestCase(2, 4, 6, 8, false)]
        [TestCase(2, 8, 3, 7, true)]
        [TestCase(2, 3, 4, 5, false)]
        [TestCase(2, 6, 4, 8, true)]
        [TestCase(6, 6, 4, 6, true)]
        public void TestOverlappingAssignmentPairs(int elf1Start, int elf1End, int elf2Start, int elf2End, bool result)
        {
            var elf1 = new Tuple<int, int>(elf1Start, elf1End);
            var elf2 = new Tuple<int, int>(elf2Start, elf2End);

            var overlaps = CampCleanup.FindOverlapsInSection(elf1, elf2);
            Assert.That(overlaps, Is.EqualTo(result));
        }

        [Test]
        public void TestSecondSmall()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var overlappingPairs = CampCleanup.CountOverlapingPairs(lines);
            Assert.That(overlappingPairs, Is.EqualTo(4));
        }

        [Test]
        public void TestSecondBig()
        {
            var lines = ReadFile.ReadLines("test-big.txt");
            var overlappingPairs = CampCleanup.CountOverlapingPairs(lines);
            Console.WriteLine(overlappingPairs);
        }
    }
}