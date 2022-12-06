using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day3
{
    internal class Day3 : IDay
    {
        private const int part2NumberOfBagsPerGroup = 3;

        public void Solve(bool part1 = true, bool part2 = true)
        {
            if (part1)
            {
                Console.WriteLine($"The sum of priorities for all bags is : {this.GetTotalPriority()}");
            }

            if (part2)
            {
                Console.WriteLine($"The sum of priorities for all groups of elves is : {this.GetTotalPriorityPart2()}");
            }
        }

        private int GetTotalPriority()
        {
            var bags = ReadFile.MapEachLineTo<Bag>("../../../Inputs/Day3.txt", (line) => Bag.FromText(line));
            return bags.Sum(b => b.Priority);
        }

        private int GetTotalPriorityPart2()
        {
            var elfGroups = ReadFile.MapEachLinesGroupTo<Bag>("../../../Inputs/Day3.txt", part2NumberOfBagsPerGroup, (line) => Bag.FromTextPart2(line));
            return elfGroups.Sum(elf => elf.Priority);
        }
    }
}
