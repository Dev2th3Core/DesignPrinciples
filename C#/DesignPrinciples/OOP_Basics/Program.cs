namespace OOP_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Displaying the main title
            PrintHeader("Object Oriented Programming");

             Encap_Abstract_Poly_Inherit.Invoke();

            // Footer message
            PrintFooter("End of OOP Demo");
        }
        // Method to print section titles in a clean and clear format
        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 80));
            Console.WriteLine(CenterText(title.ToUpper(), 80));
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
            Console.WriteLine();
        }

        // Simple footer for the console output
        static void PrintFooter(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(CenterText(message, 80));
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
        }

        // Simple dashed line for better visual separation
        static void PrintDashedLine()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();
            Console.ResetColor();
        }

        // Helper method to center-align text
        static string CenterText(string text, int width)
        {
            if (text.Length >= width) return text;
            int padding = (width - text.Length) / 2;
            return new string(' ', padding) + text;
        }
    }
}
