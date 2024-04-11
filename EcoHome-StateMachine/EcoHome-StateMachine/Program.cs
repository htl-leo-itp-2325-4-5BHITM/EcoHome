using System;
using System.Linq.Expressions;

namespace EcoHome_StateMachine
{
    internal class Program
    {
        private static string _currentState = "Start";
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zu EcoHome!\nMöchtest du die Steuerung kennenlernen? (y/n)");
            Console.Out.Flush();
            var firstInput = Console.ReadLine();
            CheckInput(firstInput);
        }

        private static void GetInput(string message)
        {
            Console.WriteLine(message);
            Console.Out.Flush();
            var newInput = Console.ReadLine();
            CheckInput(newInput);
        }

        private static void CheckInput(string input)
        {
            switch (_currentState)
            {
                case "Start":
                    switch (input)
                    {
                        case "y":
                            _currentState = "Movement instruction given";
                            GetInput("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
                            break;
                        case "n":
                            Console.WriteLine("Auf Wiedersehen!");
                            Console.Out.Flush();
                            return; 
                        default:
                            InputError("Möchtest du die Steuerung kennenlernen?");
                            break;
                    }
                    break;
                case "Movement instruction given":
                    switch (input)
                    {
                        case "LJ":
                            _currentState = "Movement learned";
                            GetInput("Bewege den rechten Joystick (RJ), um dich zu drehen.");
                            break;
                        default:
                            GetInput("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
                            break;
                    }
                    break;
            }
        }

        private static void InputError(string message)
        {
            Console.WriteLine("Deine Eingabe ist ungültig!");
            Console.Out.Flush();
            GetInput(message);
        }
    }
}