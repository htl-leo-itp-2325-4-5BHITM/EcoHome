using System;
using System.CodeDom;

namespace EcoHome_StateMachine
{
    class EcoHomeContext
    {
        private State _state = null;

        public State GetCurrentState()
        {
            return _state;
        }

        public EcoHomeContext(State state)
        {
            TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            // Console.WriteLine($"EcoHomeContext: Transition to {state.GetType().Name}.");
            _state = state;
            _state.SetContext(this);
        }

        public void HandleInput(string input)
        {
            _state.HandleInput(input);
        }
    }

    abstract class State
    {
        protected EcoHomeContext _context;

        public void SetContext(EcoHomeContext context)
        {
            _context = context;
        }

        public abstract void HandleInput(string input);
    }

    class StartState : State
    {
        public override void HandleInput(string input)
        {
            switch (input)
            {
                case "y":
                    Console.WriteLine("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
                    _context.TransitionTo(new MovementInstructionState());
                    break;
                case "n":
                    Console.WriteLine("Auf Wiedersehen!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe. Möchtest du die Steuerung kennenlernen? (y/n)");
                    break;
            }
        }
    }

    class MovementInstructionState : State
    {
        public override void HandleInput(string input)
        {
            if (input == "LJ")
            {
                Console.WriteLine("Bewege den rechten Joystick (RJ), um dich zu drehen.");
                _context.TransitionTo(new RotationInstructionState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
            }
        }
    }

    class RotationInstructionState : State
    {
        public override void HandleInput(string input)
        {
            if (input == "RJ")
            {
                Console.WriteLine("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben.");
                _context.TransitionTo(new TableState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bewege den rechten Joystick (RJ), um dich zu drehen.");
            }
        }
    }

    class TableState : State
    {
        public override void HandleInput(string input)
        {
            if (input == "IT")
            {
                Console.WriteLine("Behalte das Papier in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW).");
                _context.TransitionTo(new ThrowState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Ziele auf das Papier und versuche, ihn durch Drücken der inneren Taste (IT) aufzuheben.");
            }
        }
    }

    class ThrowState : State
    {
        public override void HandleInput(string input)
        {
            if (input == "IMW")
            {
                Console.WriteLine("Gut gemacht! Du hast den ersten Raum bestanden. Gehe in den nächsten Raum (IRG).");
                _context.TransitionTo(new EndState());
            }
            else
            {
                Console.WriteLine("Es sieht so aus, als hättest du den Müll fallen lassen. Hebe ihn wieder auf (WA).");
                _context.TransitionTo(new FloorState());
            }
        }
    }
    
    class FloorState : State
    {
        public override void HandleInput(string input)
        {
            if (input == "WA")
            {
                Console.WriteLine("Behalte den Müll in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW).");
                _context.TransitionTo(new ThrowState());
            }
            else
            {
                Console.WriteLine("Hebe den Müll wieder auf (WA).");
            }
        }
    }

    class EndState : State
    {
        public override void HandleInput(string input)
        {
            if (input == "IRG")
            {
                Console.WriteLine("Du hast das Tutorial erfolgreich abgeschlossen.");
                Environment.Exit(0);   
            }
            else
            {
                Console.WriteLine("Gehe in den nächsten Raum (IRG).");
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new EcoHomeContext(new StartState());
            Console.WriteLine("Möchtest du die Steuerung kennenlernen? (y/n)");
            while (true)
            {
                var input = Console.ReadLine();
                context.HandleInput(input);
            }
        }
        
    }
}