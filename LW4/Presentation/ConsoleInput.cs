namespace LW4.Presentation
{
    public static class ConsoleInput
    {
        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a valid integer.");
            }
        }

        public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        public static Guid ReadGuid(string message)
        {
            while (true)
            {
                Console.Write(message);

                var input = Console.ReadLine();

                if (input == "0")
                    return Guid.Empty;

                if (Guid.TryParse(input, out var value))
                    return value;

                Console.WriteLine("Please enter a valid GUID or 0 to finish.");
            }
        }

        public static DateTime ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (DateTime.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a date in yyyy-MM-dd format.");
            }
        }

        public static bool ReadBool(string message)
        {
            Console.Write($"{message} (yes/no): ");
            return Console.ReadLine()?.Trim().ToLower() is "yes" or "y";
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Pause();
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}