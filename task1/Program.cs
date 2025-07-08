using System.Text;

namespace task1
{
    //    dotnet run --project C:\...\task1 -- 5 4   --> 14253
    //    dotnet run --project C:\...\task1 -- 4 3   --> 13
    //    dotnet run --project C:\...\task1 -- 6 2   --> 123456
    //    dotnet run --project C:\...\task1 -- 7 1   --> 1
    //    dotnet run --project C:\...\task1 -- 6 6   --> 165432
    //    dotnet run --project C:\...\task1 --       --> Error: Pass exactly two arguments.
    //    dotnet run --project C:\...\task1 -- 6     --> Error: Pass exactly two arguments.
    //    dotnet run --project C:\...\task1 -- 6 6 6 --> Error: Pass exactly two arguments.
    //    dotnet run --project C:\...\task1 -- 1 6   --> Error: Insufficient memory to continue the execution of the program.
    //    dotnet run --project C:\...\task1 -- 6 1   --> 1
    //    dotnet run --project C:\...\task1 -- s a   --> Error: Invalid arguments. Both must be integers.
    //    dotnet run --project C:\...\task1 -- 0 -7  --> Error: Specified argument was out of the range of valid values. (Parameter 'Arguments must be greater than 0.')

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                    throw new ArgumentException("Pass exactly two arguments.");

                if (!int.TryParse(args[0], out int n) || !int.TryParse(args[1], out int m))
                    throw new ArgumentException("Invalid arguments. Both must be integers.");

                if (n < 1 || m < 1)
                    throw new ArgumentOutOfRangeException("Arguments must be greater than 0.");

                int i = 1;
                StringBuilder result = new StringBuilder("1");

                while (true)
                {
                    i = i + m - 1;

                    if (i % n == 1)
                        break;

                    result.Append(i % n == 0 ? n : i % n);
                }

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
