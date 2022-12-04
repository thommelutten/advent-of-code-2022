namespace Day4
{
    public class CampCleanup
    {
        public static List<Tuple<int, int>> LoadSections(string sections)
        {
            var elfPair = sections.Split(",");

            var elfPairSections = new List<Tuple<int, int>>();

            foreach (var elf in elfPair)
            {
                var elfSections = elf.Split("-");
                var elfSection = new Tuple<int, int>(
                    int.Parse(elfSections[0]),
                    int.Parse(elfSections[1])
                    );
                elfPairSections.Add(elfSection);
            }
            return elfPairSections;
        }

        public static bool OneSectionFullyContainsAnother(Tuple<int, int> elf1, Tuple<int, int> elf2)
        {
            if(IsSmaller(elf1.Item1, elf2.Item1))
            {
                if(IsBigger(elf1.Item2, elf2.Item2))
                {
                    return true;
                }

                if(IsEqualTo(elf1.Item2, elf2.Item2))
                {
                    return true;
                }

                return false;
            }

            if(IsSmaller(elf2.Item1, elf1.Item1))
            {
                if (IsBigger(elf2.Item2, elf1.Item2))
                {
                    return true;
                }

                if (IsEqualTo(elf1.Item2, elf2.Item2))
                {
                    return true;
                }

                return false;
            }

            if (IsEqualTo(elf1.Item1, elf2.Item1))
            {
                return true;
            }

            return false;
        }

        private static bool IsEqualTo(int item1, int item2)
        {
            return item1 == item2;
        }

        private static bool IsSmaller(int item1, int item2)
        {
            return item1 < item2;
        }

        private static bool IsBigger(int item1, int item2)
        {
            return item1 > item2;
        }

        public static int CountFullyContainedPairs(List<string> lines)
        {
            var fullyContainedLines = 0;
            foreach(var line in lines)
            {
                var sections = LoadSections(line);
                var fullyContained = OneSectionFullyContainsAnother(sections[0], sections[1]);
                if(fullyContained)
                {
                    fullyContainedLines++;
                }
            }
            return fullyContainedLines;
        }

        public static bool FindOverlapsInSection(Tuple<int, int> elf1, Tuple<int, int> elf2)
        {
            if (IsSmaller(elf1.Item1, elf2.Item1))
            {
                if (IsBigger(elf1.Item2, elf2.Item2))
                {
                    return true;
                }

                if (IsEqualTo(elf1.Item2, elf2.Item2))
                {
                    return true;
                }

                if (IsWithin(elf1.Item2, elf2.Item1, elf2.Item2))
                {
                    return true;
                }
                return false;
            }

            if (IsSmaller(elf2.Item1, elf1.Item1))
            {
                if (IsBigger(elf2.Item2, elf1.Item2))
                {
                    return true;
                }

                if (IsEqualTo(elf1.Item2, elf2.Item2))
                {
                    return true;
                }

                if (IsWithin(elf2.Item2, elf1.Item1, elf1.Item2))
                {
                    return true;
                }

                return false;
            }

            if (IsEqualTo(elf1.Item1, elf2.Item1))
            {
                return true;
            }

            return false;
        }

        private static bool IsWithin(int item, int start, int end)
        {
            return start <= item && item < end ||
                start < item && item <= end;
        }

        public static object CountOverlapingPairs(List<string> lines)
        {
            var overlappingPairs = 0;
            foreach (var line in lines)
            {
                var sections = LoadSections(line);
                var overlapping = FindOverlapsInSection(sections[0], sections[1]);
                if (overlapping)
                {
                    overlappingPairs++;
                }
            }
            return overlappingPairs;
        }
    }
}