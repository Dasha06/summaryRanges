public class SummaryRanges
{
    private SortedSet<int> numbers;

    public SummaryRanges()
    {
        numbers = new SortedSet<int>();
    }

    public void AddNum(int value)
    {
        numbers.Add(value);
    }

    public int[][] GetIntervals()
    {
        if (numbers.Count == 0)
            return new int[0][];

        List<int[]> intervals = new List<int[]>();
        int start = numbers.First();
        int end = start;

        foreach (int num in numbers.Skip(1))
        {
            if (num == end + 1)
            {
                end = num;
            }
            else
            {
                intervals.Add(new int[] { start, end });
                start = end = num;
            }
        }
        intervals.Add(new int[] { start, end });

        return intervals.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите команды (SummaryRanges/addNum/getIntervals) через запятую:");
        string commandInput = Console.ReadLine();
        string[] commands = commandInput.Split(',').Select(c => c.Trim()).ToArray();

        Console.WriteLine("Введите параметры для каждой команды через запятую (пустое место для SummaryRanges и getIntervals, число для addNum):");
        string paramInput = Console.ReadLine();
        string[] paramStrings = paramInput.Split(',').Select(p => p.Trim()).ToArray();

        SummaryRanges sr = new SummaryRanges();
        
        Console.Write("[");
        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] == "SummaryRanges")
            {
                Console.Write("null");
            }
            else if (commands[i] == "addNum")
            {
                int num = int.Parse(paramStrings[i]);
                sr.AddNum(num);
                Console.Write("null");
            }
            else if (commands[i] == "getIntervals")
            {
                Console.Write("[");
                int[][] intervals = sr.GetIntervals();
                for (int j = 0; j < intervals.Length; j++)
                {
                    Console.Write($"[{intervals[j][0]},{intervals[j][1]}]");
                    if (j < intervals.Length - 1)
                        Console.Write(", ");
                }
                Console.Write("]");
            }

            if (i < commands.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
}
