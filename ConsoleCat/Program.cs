using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCat
{
       
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 2;
            Console.WindowWidth = 25;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "DANCE!";
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            
            for (int i = 0; i < 20; i++) {
                Console.WriteLine("         /^¤^/");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("         /-_-/");
                Thread.Sleep(500);
                Console.Clear();
            }

        }        
    }
}
