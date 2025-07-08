using static System.Net.Mime.MediaTypeNames;

namespace task2
{
    //dotnet run --project C:\...\task2 -- C:\...\1.txt C:\...\2.txt
    internal class Program
    {
        static void Main(string[] args)
        {
            float x0, y0, r0, x1, y1, squareSum;
            int n = 100;

            string path1 = args[0];
            string path2 = args[1];

            List<string> file1 = new List<string>(File.ReadAllLines(path1));
            List<string> file2 = new List<string>(File.ReadAllLines(path2));

            string[] x0y0 = file1[0].Split(' ');

            x0 = float.Parse(x0y0[0]);
            y0 = float.Parse(x0y0[1]);
            r0 = float.Parse(file1[1]);

            int loopCount = Math.Min(n, file2.Count);
            for (int i = 0; i < loopCount; i++)
            {
                string[] x1y1 = file2[i].Split(' ');

                x1 = float.Parse(x1y1[0]);
                y1 = float.Parse(x1y1[1]);

                squareSum = (x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1);

                if (squareSum < r0 * r0)
                {
                    Console.WriteLine(1);
                }
                else if (squareSum == r0 * r0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(2);
                }
            }
        }
    }
}
