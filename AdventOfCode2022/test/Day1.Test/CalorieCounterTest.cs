using Utils;

namespace Day1.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCountCalories()
        {
            var calories = new List<string>()
            {
                "1000",
                "2000",
                "3000",
            };

            var sum = CalorieCounter.CountCalories(calories);

            Assert.That(sum, Is.EqualTo(calories.ConvertAll(int.Parse).Sum()));
        }

        [Test]
        public void TestSplitByElf()
        {
            var calories = new List<string>()
            {
                "1000",
                "2000",
                "",
                "3000"
            };

            List<List<string>> elfCalories = CalorieCounter.SplitByElf(calories);

            CollectionAssert.AreEquivalent(
                new List<List<string>>()
                {
                    new List<string>()
                    {
                        "1000",
                        "2000"
                    },
                    new List<string>()
                    {
                        "3000"
                    }
                }, elfCalories);
        }

        [Test]
        public void TestFindHighestCalorieElf()
        {
            var elvesWithCalories = new List<List<string>>()
            {
                new List<string>()
                {
                    "1000",
                    "2000"
                },
                new List<string>()
                {
                    "4000"
                }
            };

            var highestCalorieElf = CalorieCounter.FindHighestCalorieElf(elvesWithCalories);

            Assert.That(highestCalorieElf, Is.EqualTo(4000));
        }

        [Test]
        public void TestFirstSmallAssignment()
        {
            var calorieLines = ReadFile.ReadLines("first-small.txt");
            var elves = CalorieCounter.SplitByElf(calorieLines);
            var highestCalorieElf = CalorieCounter.FindHighestCalorieElf(elves);
            Assert.That(highestCalorieElf, Is.EqualTo(24000));
        }

        [Test]
        public void TestFirstBigAssignment()
        {
            var calorieLines = ReadFile.ReadLines("first-big.txt");
            var elves = CalorieCounter.SplitByElf(calorieLines);
            var highestCalorieElf = CalorieCounter.FindHighestCalorieElf(elves);
            Console.WriteLine(highestCalorieElf);
        }

        [Test]
        public void TestSecondSmallAssignment()
        {
            var calorieLines = ReadFile.ReadLines("first-small.txt");
            var elves = CalorieCounter.SplitByElf(calorieLines);
            var topThreeElves = CalorieCounter.FindTopThreeHighestCalorieElves(elves);

            Assert.That(topThreeElves.Sum(), Is.EqualTo(45000));
        }

        [Test]
        public void TestSecondBigAssignment()
        {
            var calorieLines = ReadFile.ReadLines("first-big.txt");
            var elves = CalorieCounter.SplitByElf(calorieLines);
            var topThreeElves = CalorieCounter.FindTopThreeHighestCalorieElves(elves);
            Console.WriteLine(topThreeElves.Sum());
        }
    }
}