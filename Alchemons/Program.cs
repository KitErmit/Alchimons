using System;
using System.IO;
using Alchemons.Views;
using Alchemons.Controllers;
using Alchemons.Models;
using System.Threading.Tasks;
using Alchemons.Services;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Alchemons
{
    class Program
    {
        public const string _path = "Views/Text/";
        static async Task Main(string[] args)
        {
            Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            /*
            Console.ForegroundColor = ConsoleColor.Yellow;

            await AlPedia.Load();
            
            Player player = new Player();

            ConsoleViewer consoleViewer = new ConsoleViewer(player);

            MyInterface myInterface = MyInterface.GetInstance(player);
            


            ConsoleInput inp = new ConsoleInput();

            Magaz magaz = Magaz.GetInst(myInterface, inp, consoleViewer);
            PlayerController PC = new PlayerController(player, consoleViewer, magaz, inp);
            PC.Start();
            */
            
        }

        
    }
}
