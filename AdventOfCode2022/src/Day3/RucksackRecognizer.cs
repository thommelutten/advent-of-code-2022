namespace Day3
{
    public class RucksackRecognizer
    {
        public static int CalculatePriorityScore(char item)
        {
            return (int)Enum.Parse(typeof(PriorityScore), item.ToString());
        }

        public static int CalculateTotalPriorityScore(List<string> lines)
        {
            int totalPriorityScore = 0;

            foreach (var line in lines)
            {
                var compartments = SplitIntoCompartments(line);
                var sharedItems = FindSharedItems(compartments[0], compartments[1]);
                foreach (var sharedItem in sharedItems)
                {
                    totalPriorityScore += CalculatePriorityScore(sharedItem);
                }
            }
            return totalPriorityScore;
        }

        public static char FindBadge(List<string> group)
        {
            return group[0].Intersect(group[1]).Intersect(group[2]).First();
        }

        public static int FindBadgeScores(List<string> lines)
        {
            var groups = SplitIntoElfGroups(lines);

            var badgeScore = 0;

            foreach(var group in groups)
            {
                var badge = FindBadge(group);
                badgeScore += CalculatePriorityScore(badge);
            }
            return badgeScore;
        }

        public static List<char> FindSharedItems(string compartment1, string compartment2)
        {
            return compartment1.Intersect(compartment2).ToList();
        }

        public static List<string> SplitIntoCompartments(string input)
        {
            var chunckSize = input.Length / 2;
            return Enumerable.Range(0, input.Length / chunckSize)
                .Select(i => input.Substring(i * chunckSize, chunckSize))
                .ToList();
        }

        public static List<List<string>> SplitIntoElfGroups(List<string> lines)
        {
            var chunks = lines.Chunk(3);
            var groups = new List<List<string>>();

            foreach (var chunk in chunks)
            {
                groups.Add(chunk.ToList());
            }
            return groups;
        }
    }
}