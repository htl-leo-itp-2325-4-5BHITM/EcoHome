using Moq;
using System;
using System.IO;
using System.Threading;
using System.Timers;
using NUnit.Framework;
using EcoHome_StateMachine;

using System.Threading.Tasks;

namespace TestProject2
{
    [TestFixture]
    public class StartStateTests
    {
        private StartState _state;

        [SetUp]
        public void Setup()
        {
            _state = new StartState();
        }

        [Test]
        public void OnEnter_ShouldWritePromptToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.OnEnter();

            // Assert
            Assert.AreEqual("Möchtest du die Steuerung kennenlernen? (y/n)\r\n", consoleOutput.ToString());
        }

        [Test]
        public void HandleInput_WithValidInputY_ShouldTransitionToMovementInstructionState()
        {
            // Arrange
            var context = new EcoHomeContext(new StartState());
            _state.SetContext(context);

            // Act
            _state.HandleInput("y");

            // Assert
            Assert.IsInstanceOf<MovementInstructionState>(context.State);
        }

        [Test]
        public void HandleInput_WithValidInputN_ShouldWriteGoodbyeMessageToConsoleAndExit()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.HandleInput("n");

            // Assert
            Assert.AreEqual("Auf Wiedersehen!\r\n", consoleOutput.ToString());
            Assert.AreEqual(0, Environment.ExitCode);
        }

        [Test]
        public void HandleInput_WithInvalidInput_ShouldWriteErrorMessageToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.HandleInput("InvalidInput");

            // Assert
            Assert.AreEqual("Ungültige Eingabe. Möchtest du die Steuerung kennenlernen? (y/n)\r\n", consoleOutput.ToString());
        }
    }
    [TestFixture]
    public class MovementInstructionStateTests
    {
        private MovementInstructionState _state;

        [SetUp]
        public void Setup()
        {
            _state = new MovementInstructionState();
        }

        [Test]
        public void OnEnter_ShouldWriteInstructionsToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.OnEnter();

            // Assert
            Assert.AreEqual("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.\r\n",
                consoleOutput.ToString());
        }

        [Test]
        public void HandleInput_WithValidInput_ShouldTransitionToRotationInstructionState()
        {
            // Arrange
            var context = new EcoHomeContext(new MovementInstructionState());
            _state.SetContext(context);

            // Act
            _state.HandleInput("LJ");

            // Assert
            Assert.IsInstanceOf<RotationInstructionState>(context.State);
        }

        [Test]
        public void HandleInput_WithInvalidInput_ShouldWriteErrorMessageToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.HandleInput("InvalidInput");

            // Assert
            Assert.AreEqual(
                "Ungültige Eingabe. Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.\r\n",
                consoleOutput.ToString());
        }
    }

    [TestFixture]
    public class RotationInstructionStateTests
    {
        private RotationInstructionState _state;

        [SetUp]
        public void Setup()
        {
            _state = new RotationInstructionState();
        }

        [Test]
        public void OnEnter_ShouldWriteInstructionsToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.OnEnter();

            // Assert
            Assert.AreEqual("Bewege den rechten Joystick (RJ), um dich zu drehen.\r\n", consoleOutput.ToString());
        }

        [Test]
        public void HandleInput_WithValidInput_ShouldTransitionToTableState()
        {
            // Arrange
            var context = new EcoHomeContext(new RotationInstructionState());
            _state.SetContext(context);

            // Act
            _state.HandleInput("RJ");

            // Assert
            Assert.IsInstanceOf<TableState>(context.State);
        }

        [Test]
        public void HandleInput_WithInvalidInput_ShouldWriteErrorMessageToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.HandleInput("InvalidInput");

            // Assert
            Assert.AreEqual("Ungültige Eingabe. Bewege den rechten Joystick (RJ), um dich zu drehen.\r\n",
                consoleOutput.ToString());
        }
    }

    [TestFixture]
    public class TableStateTests
    {
        private TableState _state;
        private EcoHomeContext _context;

        [SetUp]
        public void Setup()
        {
            _state = new TableState();
            _context = new EcoHomeContext(new TableState());
            _state.SetContext(_context);
        }

        [Test]
        public void OnEnter_ShouldWriteInstructionsToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.OnEnter();

            // Assert
            Assert.AreEqual(
                "Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben.\r\n",
                consoleOutput.ToString());
        }

        [Test]
        public void HandleInput_WithValidInput_ShouldTransitionToThrowState()
        {
            // Act
            _state.HandleInput("IT");

            // Assert
            Assert.IsInstanceOf<ThrowState>(_context.State);
        }

        [Test]
        public void HandleInput_WithInvalidInput_ShouldWriteErrorMessageToConsole()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            _state.HandleInput("InvalidInput");

            // Assert
            Assert.AreEqual(
                "Ungültige Eingabe. Ziele auf das Papier und versuche, ihn durch Drücken der inneren Taste (IT) aufzuheben.\r\n",
                consoleOutput.ToString());
        }

        

    }
    
    [TestFixture]
    public class ThrowStateTests
    {
            private ThrowState _state;

            [SetUp]
            public void Setup()
            {
                _state = new ThrowState();
            }

            [Test]
            public void OnEnter_ShouldWriteInstructionsToConsole()
            {
                // Arrange
                var consoleOutput = new StringWriter();
                Console.SetOut(consoleOutput);

                // Act
                _state.OnEnter();

                // Assert
                Assert.AreEqual(
                    "Behalte das Papier in der Hand und versuche, ihn in den Mülleimer zu werfen (IMW).\r\n",
                    consoleOutput.ToString());
            }

            [Test]
            public void HandleInput_WithValidInput_ShouldTransitionToEndState()
            {
                // Arrange
                var context = new EcoHomeContext(new FloorState());
                _state.SetContext(context);

                // Act
                _state.HandleInput("IMW");

                // Assert
                Assert.IsInstanceOf<EndState>(context.State);
            }

            [Test]
            public void HandleInput_WithInvalidInput_ShouldTransitionToFloorState()
            {
                // Arrange
                var context = new EcoHomeContext(new ThrowState());
                _state.SetContext(context);

                // Act
                _state.HandleInput("InvalidInput");

                // Assert
                Assert.IsInstanceOf<FloorState>(context.State);
            }
        }

     [TestFixture]
     public class FloorStateTests
     {
         private FloorState _state;
       [SetUp]
         public void Setup()
         {
             _state = new FloorState();
         }
       [Test]
         public void OnEnter_ShouldWriteInstructionsToConsole()
         {
             // Arrange
             var consoleOutput = new StringWriter();
             Console.SetOut(consoleOutput);
           // Act
             _state.OnEnter();
           // Assert
             Assert.AreEqual("Es sieht so aus, als hättest du den Müll fallen lassen. Hebe ihn wieder auf (WA).\r\n",
                 consoleOutput.ToString());
         }
       [Test]
         public void HandleInput_WithValidInput_ShouldTransitionToThrowState()
         {
             // Arrange
             var context = new EcoHomeContext(new TableState());
             _state.SetContext(context);
           // Act
             _state.HandleInput("WA");
           // Assert
             Assert.IsInstanceOf<ThrowState>(context.State);
         }
       [Test]
         public void HandleInput_WithInvalidInput_ShouldWriteErrorMessageToConsole()
         {
             // Arrange
             var consoleOutput = new StringWriter();
             Console.SetOut(consoleOutput);
           // Act
             _state.HandleInput("InvalidInput");
           // Assert
             Assert.AreEqual("Hebe den Müll wieder auf (WA).\r\n", consoleOutput.ToString());
         }
   }
     [TestFixture]
     public class EndStateTests
     {
         private EndState _state;
       [SetUp]
         public void Setup()
         {
             _state = new EndState();
         }
       [Test]
         public void OnEnter_ShouldWriteSuccessMessageToConsole()
         {
             // Arrange
             var consoleOutput = new StringWriter();
             Console.SetOut(consoleOutput);
           // Act
             _state.OnEnter();
           // Assert
             Assert.AreEqual("Du hast das Tutorial erfolgreich abgeschlossen.\r\n", consoleOutput.ToString());
         }
       [Test]
         public void HandleInput_ShouldNotThrowException()
         {
             // Arrange
             var input = "some input";
           // Act & Assert
             Assert.DoesNotThrow(() => _state.HandleInput(input));
         }
     }

     [TestFixture]
     public class MovementInstructionStateTestsSecond
     {
         
         [Test]
         public void Test_StartRepeatAction_AnonymousMethod()
         {
             // Arrange
             var state = new MovementInstructionState();
             var stringWriter = new StringWriter();
             Console.SetOut(stringWriter);

             // Act
             state.StartRepeatAction(() => Console.WriteLine("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben."), 5000);

             // Wait for the action to be executed
             Thread.Sleep(6000);

             // Assert
             var output = stringWriter.ToString();
             Assert.That(output, Does.Contain("Siehst du den Müll auf dem Tisch? Ziele darauf und versuche, den Müll durch Drücken der inneren Taste (IT) aufzuheben."));
         }
         
     }

     [TestFixture]
     public class TableStateTestsSecond
     {
         [Test]
         public void Test_StartRepeatAction_AnonymousMethod_TableState()
         {
             // Arrange
             var state = new TableState();
             var stringWriter = new StringWriter();
             Console.SetOut(stringWriter);

             // Act
             state.StartRepeatAction(() => Console.WriteLine("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen."), 5000);

             // Wait for the action to be executed
             Thread.Sleep(6000);

             // Assert
             var output = stringWriter.ToString();
             Assert.That(output, Does.Contain("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen."));
         }
     }



}
    
    