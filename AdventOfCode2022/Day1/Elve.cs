namespace AdventOfCode2022.Day1
{
    internal class Elve
    {
        public int CaloriesCarried { get; private set; }

        public Elve()
            => this.CaloriesCarried = 0;

        public void AddCalories(int calories)
            => this.CaloriesCarried += calories;

        public static bool operator > (Elve e1, Elve e2)
            => (e1.CaloriesCarried > e2.CaloriesCarried);

        public static bool operator < (Elve e1, Elve e2)
            => (e1.CaloriesCarried < e2.CaloriesCarried);
    }
}
