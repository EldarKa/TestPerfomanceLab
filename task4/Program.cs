namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            List<string> lines = File.ReadAllLines(filePath).ToList();
            int[] nums = new int[lines.Count];
            int[] sumNum = new int[lines.Count];

            for (int i = 0; i < lines.Count; i++)
            {
                nums[i] = int.Parse(lines[i]);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < lines.Count; j++)
                {
                    sum += Math.Abs(nums[i] - nums[j]);
                }
                sumNum[i] = sum;
            }

            List<int> results = sumNum.ToList();
            Console.WriteLine(results.Min());
        }
    }
}
