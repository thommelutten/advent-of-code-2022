namespace Day2
{
    public class RockPaperScissor
    {
        public static int CalculatePoints(string duel)
        {
            var handShapes = duel.Split(" ");

            var roundPoints = CalculateRoundPoints(handShapes[0], handShapes[1]);
            var handShapePoints = CalculateHandShapePoints(handShapes[1]);

            return roundPoints + handShapePoints;
        }

        public static int CalculateHandShapePoints(string handShape)
        {
            switch (handShape)
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
                default:
                    return 0;
            }
        }

        public static int CalculateRoundPoints(string opponent, string proponent)
        {
            if (opponent == "A" && proponent == "X" ||
                opponent == "B" && proponent == "Y" ||
                opponent == "C" && proponent == "Z")
            {
                return 3;

            }

            var winningCombinations = new List<Tuple<string, string>>()
            {
                Tuple.Create("A", "Y"),
                Tuple.Create("B", "Z"),
                Tuple.Create("C", "X"),
            };

            if(winningCombinations.Any(wc => wc.Item1 == opponent && wc.Item2 == proponent))
            {
                return 6;
            }

            return 0;
        }

        public static string CounterHand(string opponent, string proponent)
        {
            var drawCombinations = new List<Tuple<string, string>>()
            {
                Tuple.Create("A", "X"),
                Tuple.Create("B", "Y"),
                Tuple.Create("C", "Z"),
            };

            var losingCombinations = new List<Tuple<string, string>>()
            {
                Tuple.Create("A", "Z"),
                Tuple.Create("B", "X"),
                Tuple.Create("C", "Y"),
            };

            var winningCombinations = new List<Tuple<string, string>>()
            {
                Tuple.Create("A", "Y"),
                Tuple.Create("B", "Z"),
                Tuple.Create("C", "X"),
            };

            if (proponent == "Y")
            {
                return drawCombinations.Find(dc => dc.Item1 == opponent)!.Item2;
            }

            if(proponent == "X")
            {
                return losingCombinations.Find(lc => lc.Item1 == opponent)!.Item2;
            }
            
            return winningCombinations.Find(wc => wc.Item1 == opponent)!.Item2;   
        }

        public static int CalculatePointsWithCounterHand(string duel)
        {
            var handShapes = duel.Split(" ");

            var counterHand = CounterHand(handShapes[0], handShapes[1]);

            var roundPoints = CalculateRoundPoints(handShapes[0], counterHand);
            var handShapePoints = CalculateHandShapePoints(counterHand);

            return roundPoints + handShapePoints;
        }
    }
}

// Y - draw
//  A - X
//  B - Y
//  C - Z
// X - loss
//  A - Z
//  B - X
//  C - Y
// Z - win
//  A - Y
//  B - Z
//  C - X