namespace AdventOfCode2022.Common
{
    public static class ReadFile
    {
        public static void ForEachLine(string filePath, Action<string> fn)
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                fn(line);
            }
        }

        public static IEnumerable<T> MapEachLineTo<T>(string filePath, Func<string, T> fn)
        {
            List<T> result = new List<T>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                result.Add(fn(line));
            }

            return result;
        }

        public static IEnumerable<T> MapEachLinesGroupTo<T>(string filePath, string groupDelimiter, Func<IReadOnlyList<string>, T> fn)
        {
            List<T> result = new List<T>();
            var lines = File.ReadAllLines(filePath);

            List<string> group = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == groupDelimiter)
                {
                    result.Add(fn(group));
                    group.Clear();
                }
                else
                {
                    group.Add(lines[i]);
                }
            }

            return result;
        }
    }
}
