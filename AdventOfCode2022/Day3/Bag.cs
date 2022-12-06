namespace AdventOfCode2022.Day3
{
    internal class Bag
    {
        public char CompartmentCommonItem { get; private set; }

        public int Priority
        {
            get => this.priority.HasValue ? this.priority.Value : throw new Exception("Priority not computed yet"); 
        }

        private int? priority;

        public Bag (char compartmentCommonItem)
        {
            this.CompartmentCommonItem = compartmentCommonItem;
        }

        public static Bag FromText(string input)
        {
            var part1 = input.Substring(0, input.Length / 2);
            var part2 = input.Substring(input.Length / 2);

            char common = part1.Intersect(part2).FirstOrDefault();

            var bag = new Bag(common);
            bag.ComputePriority();

            return bag;
        }

        public static Bag FromTextPart2(IReadOnlyList<string> input)
        {
            var first = input.ElementAt(0);
            var second = input.ElementAt(1);
            var third = input.ElementAt(2);

            char common = first.Intersect(second).Intersect(third).FirstOrDefault();

            var bag = new Bag(common);
            bag.ComputePriority();

            return bag;
        }

        private void ComputePriority()
        {
            bool isMaj = this.CompartmentCommonItem >= 65 && this.CompartmentCommonItem <= 90;
            this.priority = isMaj ? (this.CompartmentCommonItem - 38) : (this.CompartmentCommonItem - 96);
        }
    }
}
