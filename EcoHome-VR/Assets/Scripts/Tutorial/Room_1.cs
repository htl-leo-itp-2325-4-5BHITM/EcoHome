using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

namespace Room_1
{
    /*
    public enum ControllerInputs {
        LeftThumbStick,
        LeftGripButton,
        RightThumbStick,
        RightGripButton
    }

    class TutorialContext
    {
        private State _state = null;

        public TutorialContext(State state)
        {
            this.TransitionTo(state);
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

        public void HandleInput(ControllerInputs input)
        {
            _state.HandleInput(input);
        }

    }

    abstract class State
    {
        protected TutorialContext _context;
        protected Timer repeatTimer;

        public void SetContext(TutorialContext context)
        {
            _context = context;
        }

        public abstract void HandleInput(ControllerInputs input);

        public virtual void OnEnter()
        {}

        public virtual void OnExit()
        {
            StopRepeatAction();
        }

        protected void StartRepeatAction(Action action, int interval)
        {
            repeatTimer?.Stop();    //stopping timer if already runs

            repeatTimer = new Timer(interval);
            repeatTimer.Elapsed += (sender, e) => action();
            repeatTimer.AutoReset = true;
            repeatTimer.Start();
        }

        protected void StopRepeatAction()
        {
            repeatTimer?.Stop();
        }
    }

    class StartState : State
    {

        public override void OnEnter()
        {
            //base.OnEnter();
            Console.WriteLine("Möchtest du die Steuerung kennenlernen? (y/n)");
        }
        public override void HandleInput(ControllerInputs input)
        {
            switch (input)
            {
                case "y":
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

        public override void OnEnter()
        {
            Console.WriteLine("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.");
            StartRepeatAction( () => Console.WriteLine("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen."), 5000);
        }
        public override void HandleInput(ControllerInputs input)
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

    class RotationInstructionState : State
    {

        public override void OnEnter()
        {
            Console.WriteLine("Bewege den rechten Joystick (RJ), um dich zu drehen.");
            StartRepeatAction( () => Console.WriteLine("Bewege den rechten Joystick (RJ), um dich zu drehen."), 5000);
        }
        public override void HandleInput(ControllerInputs input)
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

    class TableState : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben.");
            StartRepeatAction( () => Console.WriteLine("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben."), 5000);
        }
        public override void HandleInput(ControllerInputs input)
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

    class ThrowState : State
    {

        public override void OnEnter()
        {
            Console.WriteLine("Behalte das Papier in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW).");
            StartRepeatAction( () => Console.WriteLine("Behalte das Papier in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW)."), 5000);
        }
        public override void HandleInput(ControllerInputs input)
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
    
    class FloorState : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("Es sieht so aus, als hättest du den Müll fallen lassen. Hebe ihn wieder auf (WA).");
            StartRepeatAction( () => Console.WriteLine("Es sieht so aus, als hättest du den Müll fallen lassen. Hebe ihn wieder auf (WA)."), 5000);
        }

        public override void HandleInput(ControllerInputs input)
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

    class EndState : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("Du hast das Tutorial erfolgreich abgeschlossen.");
            Environment.Exit(0);   

        }
        
        public override void HandleInput(ControllerInputs input)
        {

        }
        
    }

    class Room_1
    {
        [SerializeField] private Audio audioScript;
        [SerializeField] private Cntrl_Listener listenerScript;
        [SerializeField] private InputData _inputData;

        //var context = new TutorialContext(new StartState());

/*
        void Start()
        {
            _inputData = GetComponent<InputData>();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftThumbStick))
                {
                    if (Mathf.Abs(leftThumbStick.y) >= 0.80 || Mathf.Abs(leftThumbStick.y) <= -0.80)
                    {
                        leftStickUsed = true;
                        //context.HandleInput(ControllerInputs.Lef);
                        Debug.Log("used left stick");
                    }
                }

                if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 rightThumbStick))
                {
                    if (Mathf.Abs(rightThumbStick.x) >= 0.80 || Mathf.Abs(rightThumbStick.x) <= -0.80)
                    {
                        righStickUsed = true;
                        Debug.Log("used right stick");
                    }
                }

                if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool leftGripPressed))
                {
                    if (leftGripPressed && !leftGripButtonUsed)
                    {
                        leftGripButtonUsed = true;
                        Debug.Log("Left grip button pressed: " + leftGripButtonUsed);
                        // Trigger the event or method to play clip_2
                    }
                    else if (!leftGripPressed && leftGripButtonUsed)
                    {
                    leftGripButtonUsed = false;
                    Debug.Log("Left grip button pressed: " + leftGripButtonUsed);
                    // Trigger the event or method to replay clip_1
                    }
                }

                if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed))
                {
                    if (rightGripPressed && !rightGripButtonUsed)
                    {
                        rightGripButtonUsed = true;
                        Debug.Log("right grip button pressed: " + rightGripButtonUsed);
                        // Trigger the event or method to play clip_2
                    }
                    else if (!rightGripPressed && rightGripButtonUsed)
                    {
                        rightGripButtonUsed = false;
                        Debug.Log("right grip button pressed: " + rightGripButtonUsed);
                        // Trigger the event or method to replay clip_1
                    }   
                }

                context.HandleInput(input);
            }
        }
        
        
    }
    */
}

