using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day1
{
    public class Day1 : IDay
    {
        public void Solve(bool part1 = true, bool part2 = true)
        {
            if (part1)
            {
                Console.WriteLine($"The highest amount of calories carried by an elve is : {this.GetHighestCaloriesAmount()}");
            }

            if (part2)
            {
                Console.WriteLine($"The top-three elves are carrying {this.GetTopThreeCaloriesAmount()} calories in total.");
            }
        }

        private int GetHighestCaloriesAmount()
        {
            int max = int.MinValue;
            int currentElveCaloriesSum = 0;

            ReadFile.ForEachLine("../../../Inputs/Day1.txt", (line) =>
            {
                if (line == string.Empty)
                {
                    max = (max < currentElveCaloriesSum) ? currentElveCaloriesSum : max;
                    currentElveCaloriesSum = 0;
                }
                else
                {
                    currentElveCaloriesSum += int.Parse(line);
                }
            });

            return max;
        }

        private int GetTopThreeCaloriesAmount()
        {
            var elves = ReadFile.MapEachLinesGroupTo<Elve>("../../../Inputs/Day1.txt", string.Empty, (lines) =>
            {
                var elve = new Elve();

                foreach (var l in lines)
                {
                    elve.AddCalories(int.Parse(l));
                }

                return elve;
            });

            return elves.OrderByDescending(e => e.CaloriesCarried)
                .Take(3)
                .Sum(e => e.CaloriesCarried);
        }
    }
}
