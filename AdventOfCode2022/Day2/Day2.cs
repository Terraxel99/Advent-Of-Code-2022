using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day2
{
    internal class Day2 : IDay
    {
        public void Solve(bool part1 = true, bool part2 = true)
        {
            if (part1)
            {
                Console.WriteLine($"The score given by the strategy guide is {GetScoreOfStrategyGuideForPart1()}");
            }

            if (part2)
            {
                Console.WriteLine($"The score given by the strategy guide is {GetScoreOfStrategyGuideForPart2()}");
            }
        }
        private int GetScoreOfStrategyGuideForPart1()
            => GetScoreOfStrategyGuide((line) => GameRound.FromTextPart1(line));

        private int GetScoreOfStrategyGuideForPart2()
            => GetScoreOfStrategyGuide((line) => GameRound.FromTextPart2(line));

        private int GetScoreOfStrategyGuide(Func<string, GameRound> fn)
        {
            var rounds = ReadFile.MapEachLineTo<GameRound>("../../../Inputs/Day2.txt", (line) =>
            {
                return fn(line);
            });

            return rounds.Sum(r => r.CalculateScore());
        }
    }
}
