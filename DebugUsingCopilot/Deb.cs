using System;
class Debugging
{
    static void Main()
    {
        Console.WriteLine("Please enter a non-negative integer number:");

        int number;
        while (true)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer number:");
                continue;
            }
            if (number < 0)
            {
                Console.WriteLine("Negative number entered. Please enter a non-negative integer:");
                continue;
            }
            break;
        }

        double res = Math.Sqrt(number);
        Console.WriteLine($"The square root of {number} is {res}");
    }
}