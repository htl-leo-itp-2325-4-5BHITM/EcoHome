using System;

namespace EcoHome_StateMachine
{
    class EcoHomeContext
    {
        private State _state = null;

        public EcoHomeContext(State state)
        {
            this.TransitionTo(state);
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
                Console.WriteLine("Steuerung abgeschlossen. Viel Spaß!");
                _context.TransitionTo(new EndState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bewege den rechten Joystick (RJ), um dich zu drehen.");
            }
        }
    }

    class EndState : State
    {
        public override void HandleInput(string input)
        {
            Console.WriteLine("Steuerung abgeschlossen. Keine weiteren Aktionen möglich.");
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