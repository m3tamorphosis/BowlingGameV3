using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            Console.WriteLine("Input Frames");
            string input = Console.ReadLine();
            game.Frames(input);
            int score = game.TotalScore();
            Console.WriteLine(score);
            Console.ReadLine();
        }
    }
}
