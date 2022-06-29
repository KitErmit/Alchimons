using System;
namespace Alchemons.Controllers
{
    public interface InputInterface
    {
        public char MenuInput();
        public string StringInput();
    }


    public class ConsoleInput : InputInterface
    {
        public char MenuInput()
        {
            var defColor = Console.ForegroundColor;
            Console.ResetColor();
            char Char = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.ForegroundColor = defColor;
            return Char;
        }

        public string StringInput()
        {
            var defColor = Console.ForegroundColor;
            Console.ResetColor();
            string input = Console.ReadLine();
            Console.ForegroundColor = defColor;
            return input;
        }
    }
}
