using NUnit.Framework;
using System;
using System.IO;

namespace EcoHome_StateMachine.Tests
{
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
            Assert.AreEqual("Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.\r\n", consoleOutput.ToString());
        }

        [Test]
        public void HandleInput_WithValidInput_ShouldTransitionToRotationInstructionState()
        {
            // Arrange
            var context = new StateMachineContext();
            _state.SetContext(context);

            // Act
            _state.HandleInput("LJ");

            // Assert
            Assert.IsInstanceOf<RotationInstructionState>(context.CurrentState);
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
            Assert.AreEqual("Ungültige Eingabe. Bewege den linken Joystick (LJ), um dich durch den Raum zu bewegen.\r\n", consoleOutput.ToString());
        }
    }
}