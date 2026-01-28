using System;

public static class InputHelper
{
    public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out result) && result >= min && result <= max)
            {
                return result;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Vui lòng nhập số nguyên hợp lệ ({min} - {max}).");
            Console.ResetColor();
        }
    }

    public static double ReadDouble(string prompt, double min = 0.0, double max = 10.0)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (double.TryParse(input, out result) && result >= min && result <= max)
            {
                return result;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Vui lòng nhập số thực hợp lệ ({min} - {max}).");
            Console.ResetColor();
        }
    }

    public static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Thông tin không được để trống.");
        }
    }
}