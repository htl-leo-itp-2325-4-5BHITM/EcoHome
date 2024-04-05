using System;

namespace EcoHome_StateMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Game? y/n");
            Console.Out.Flush();
            var startGame = Console.ReadLine();
        }
    }
}