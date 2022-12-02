namespace Day1
{
    public class CalorieCounter
    {
        public static int CountCalories(List<string> calories)
        {
            return calories.ConvertAll(int.Parse).Sum();
        }

        public static int FindHighestCalorieElf(List<List<string>> elvesWithCalories)
        {
            var elvesTotalCalories = new List<int>();
            foreach (var elfWithCalories in elvesWithCalories)
            {
                elvesTotalCalories.Add(CountCalories(elfWithCalories));
            }
            return elvesTotalCalories.Max();
        }

        public static List<int> FindTopThreeHighestCalorieElves(List<List<string>> elvesWithCalories)
        {
            var elvesTotalCalories = new List<int>();
            foreach (var elfWithCalories in elvesWithCalories)
            {
                elvesTotalCalories.Add(CountCalories(elfWithCalories));
            }
            return elvesTotalCalories.OrderByDescending(etc => etc).Take(3).ToList();
        }

        public static List<List<string>> SplitByElf(List<string> calories)
        {
            var elves = new List<List<string>>();

            var temp = new List<string>();

            foreach (var calorie in calories)
            {
                if (string.IsNullOrEmpty(calorie))
                {
                    var elf = new List<string>(temp);
                    elves.Add(elf);
                    temp.Clear();
                    continue;
                }

                temp.Add(calorie);
            }

            elves.Add(temp);

            return elves;
        }
    }
}