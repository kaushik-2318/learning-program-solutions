using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Financial Forecasting Tool ===");
            Console.WriteLine("Recursion is a method where the solution to a problem depends on solutions to smaller instances of the same problem.");
            Console.WriteLine("It simplifies problems by breaking them down into simpler sub-problems of the same type.\n");

            Console.Write("Enter initial investment amount: ");
            decimal initialAmount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter annual growth rate (e.g., 5 for 5%): ");
            double growthRate = double.Parse(Console.ReadLine()) / 100;

            Console.Write("Enter number of years to forecast: ");
            int years = int.Parse(Console.ReadLine());

            Console.WriteLine("\n=== Forecast Results ===");
            Console.WriteLine($"Year 0: {initialAmount:C}");

            ForecastRecursive(initialAmount, growthRate, years, 1);

            Console.WriteLine("\n=== Algorithm Analysis ===");
            Console.WriteLine("Time Complexity: O(n) - Linear time complexity where n is the number of years");
            Console.WriteLine("Space Complexity: O(n) - Due to the call stack depth in recursion");
            Console.WriteLine("\nOptimization Strategies:");
            Console.WriteLine("1. Memoization: Cache results to avoid redundant calculations");
            Console.WriteLine("2. Iterative approach: Convert to loop to avoid stack overflow");
            Console.WriteLine("3. Tail recursion: Some compilers can optimize tail-recursive functions");
        }

        static void ForecastRecursive(decimal currentAmount, double growthRate, int totalYears, int currentYear)
        {
            if (currentYear > totalYears)
                return;

            decimal newAmount = currentAmount * (1 + (decimal)growthRate);
            Console.WriteLine($"Year {currentYear}: {newAmount:C}");

            // Recursive call
            ForecastRecursive(newAmount, growthRate, totalYears, currentYear + 1);
        }

        static decimal ForecastMemoized(decimal amount, double rate, int years, Dictionary<int, decimal> cache = null)
        {
            cache = cache ?? new Dictionary<int, decimal>();

            if (years == 0)
                return amount;

            if (cache.TryGetValue(years, out decimal cachedValue))
                return cachedValue;

            decimal result = ForecastMemoized(amount, rate, years - 1, cache) * (1 + (decimal)rate);
            cache[years] = result;
            return result;
        }
    }
}