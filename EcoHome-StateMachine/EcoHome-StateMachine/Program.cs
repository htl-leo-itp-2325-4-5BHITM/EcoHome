using System;
using System.Timers;

namespace EcoHome_StateMachine
{
    public class EcoHomeContext
    {
        private State _state = null;

        public EcoHomeContext(State state)
        {
            this.TransitionTo(state);
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        public void TransitionTo(State state)
        {
            if (_state != null)
            {
                _state.OnExit();
            }
            
            _state = state;
            _state.SetContext(this);
            _state.OnEnter();
        }

        public void HandleInput(string input)
        {
            _state.HandleInput(input);
        }
    }

    public abstract class State
    {
        protected EcoHomeContext _context;
        protected Timer repeatTimer;

        public void SetContext(EcoHomeContext context)
        {
            _context = context;
        }

        public abstract void HandleInput(string input);

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
            StopRepeatAction();
        }

        
        public virtual void StartRepeatAction(Action action, int interval)
        {
            repeatTimer?.Stop();    //stopping timer if already runs

            repeatTimer = new Timer(interval);
            repeatTimer.Elapsed += (sender, e) => action();
            repeatTimer.AutoReset = true;
            repeatTimer.Start();
        }

        public virtual void StopRepeatAction()
        {
            repeatTimer?.Stop();
        }
    }

    public class StartState : State
    {

        public override void OnEnter()
        {
            //base.OnEnter();
            Console.WriteLine("Möchtest du die Steuerung kennenlernen? (y/n)");
        }
        public override void HandleInput(string input)
        {
            switch (input)
            {
                case "y":
                    _context.TransitionTo(new MovementInstructionState());
                    return;
                case "n":
                    Console.WriteLine("Auf Wiedersehen!");
                    
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Möchtest du die Steuerung kennenlernen? (y/n)");
                    return;
            }
        }
    }

    public class MovementInstructionState : State
    {

        public override void OnEnter()
        {
            Console.WriteLine("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
            StartRepeatAction( () => Console.WriteLine("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen."), 5000);
        }
        public override void HandleInput(string input)
        {
            if (input == "LJ")
            {
                _context.TransitionTo(new RotationInstructionState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
            }
        }
    }

    public class RotationInstructionState : State
    {

        public override void OnEnter()
        {
            Console.WriteLine("Bewege den rechten Joystick (RJ), um dich zu drehen.");
            StartRepeatAction( () => Console.WriteLine("Bewege den rechten Joystick (RJ), um dich zu drehen."), 5000);
        }
        public override void HandleInput(string input)
        {
            if (input == "RJ")
            {
                _context.TransitionTo(new TableState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bewege den rechten Joystick (RJ), um dich zu drehen.");
            }
        }
    }

    public class TableState : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben.");
            StartRepeatAction( () => Console.WriteLine("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben."), 5000);
        }
        public override void HandleInput(string input)
        {
            if (input == "IT")
            {
                _context.TransitionTo(new ThrowState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Ziele auf das Papier und versuche, ihn durch Drücken der inneren Taste (IT) aufzuheben.");
            }
        }
    }

    public class ThrowState : State
    {

        public override void OnEnter()
        {
            Console.WriteLine("Behalte das Papier in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW).");
            StartRepeatAction( () => Console.WriteLine("Behalte das Papier in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW)."), 5000);
        }
        public override void HandleInput(string input)
        {
            if (input == "IMW")
            {
                _context.TransitionTo(new EndState());
            }
            else
            {
                _context.TransitionTo(new FloorState());
            }
        }
    }
    
    public class FloorState : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("Es sieht so aus, als hättest du den Müll fallen lassen. Hebe ihn wieder auf (WA).");
            StartRepeatAction( () => Console.WriteLine("Es sieht so aus, als hättest du den Müll fallen lassen. Hebe ihn wieder auf (WA)."), 5000);
        }

        public override void HandleInput(string input)
        {
            if (input == "WA")
            {
                _context.TransitionTo(new ThrowState());
            }
            else
            {
                Console.WriteLine("Hebe den Müll wieder auf (WA).");
            }
        }
    }

    public class EndState : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("Du hast das Tutorial erfolgreich abgeschlossen.");
            //Environment.Exit(0);
            return;

        }
        
        public override void HandleInput(string input)
        {

        }
        
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var context = new EcoHomeContext(new StartState());
            while (true)
            {
                var input = Console.ReadLine();
                context.HandleInput(input);
            }
        }
        
    }
}
