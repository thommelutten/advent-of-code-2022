using Utils;

namespace Day2.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("X", 1)]
        [TestCase("Y", 2)]
        [TestCase("Z", 3)]
        public void TestCalculateHandShapePoints(string handShape, int result)
        {
            var points = RockPaperScissor.CalculateHandShapePoints(handShape);
            Assert.That(points, Is.EqualTo(result));
        }

        [TestCase("A", "Y", 6)]
        [TestCase("A", "X", 3)]
        [TestCase("A", "Z", 0)]
        [TestCase("B", "Z", 6)]
        [TestCase("B", "Y", 3)]
        [TestCase("B", "X", 0)]
        [TestCase("C", "X", 6)]
        [TestCase("C", "Z", 3)]
        [TestCase("C", "Y", 0)]

        public void TestCalculateRoundPoints(string opponent, string proponent, int result)
        {
            var points = RockPaperScissor.CalculateRoundPoints(opponent, proponent);
            Assert.That(points, Is.EqualTo(result));
        }

        [TestCase("A Y", 8)]
        [TestCase("B X", 1)]
        [TestCase("C Z", 6)]
        public void TestCalculatePoints(string handShapes, int result)
        {
            var points = RockPaperScissor.CalculatePoints(handShapes);
            Assert.That(points, Is.EqualTo(result));
        }

        [Test]
        public void TestFirstSmall()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var points = 0;
            foreach (var line in lines)
            {
                points += RockPaperScissor.CalculatePoints(line);
            }
            Assert.That(points, Is.EqualTo(15));
        }

        [Test]
        public void TestFirstBig()
        {
            var lines = ReadFile.ReadLines("test-big.txt");
            var points = 0;
            foreach (var line in lines)
            {
                points += RockPaperScissor.CalculatePoints(line);
            }
            Console.WriteLine(points);
        }

        [TestCase("A", "Y", "X")]
        [TestCase("B", "X", "X")]
        [TestCase("C", "Z", "X")]
        public void TestCounterHand(string opponent, string proponent, string result)
        {
            var counterHand = RockPaperScissor.CounterHand(opponent, proponent);
            Assert.That(counterHand, Is.EqualTo(result));
        }

        [TestCase("A Y", 4)]
        [TestCase("B X", 1)]
        [TestCase("C Z", 7)]
        public void TestCalculatePointsWithCounterHand(string handShapes, int result)
        {
            var points = RockPaperScissor.CalculatePointsWithCounterHand(handShapes);
            Assert.That(points, Is.EqualTo(result));
        }

        [Test]
        public void TestSecondSmall()
        {
            var lines = ReadFile.ReadLines("test-small.txt");
            var points = 0;
            foreach (var line in lines)
            {
                points += RockPaperScissor.CalculatePointsWithCounterHand(line);
            }
            Assert.That(points, Is.EqualTo(12));
        }

        [Test]
        public void TestSecondBig()
        {
            var lines = ReadFile.ReadLines("test-big.txt");
            var points = 0;
            foreach (var line in lines)
            {
                points += RockPaperScissor.CalculatePointsWithCounterHand(line);
            }
            Console.WriteLine(points);
        }
    }
}