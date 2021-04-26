using NASA.Mars.Contracts.Parsers;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using NASA.Mars.Contracts;
using NASA.Mars.Contracts.Sequencers;
using NASA.Mars.Impl.Parsers;
using NASA.Mars.Contracts.Commands;
using System.Collections.Generic;
using NASA.Mars.Impl;
using NASA.Mars.Contracts.Constraints;
using NASA.Mars.Impl.Constraints;
using NASA.Mars.Impl.Sequencers;

namespace NASA.Mars.Specs.Steps
{
    [Binding]
    public class MarsRoverSteps
    {
        private IPositionParser _positionParser;
        private IPosition _position;
        private IRover _rover;
        private ICommandSequencer _commandSequencer;
        private string _commandSequence;
        // private List<ICommand> _commands;
        private IConstraint _plateauConstraint;

        [Given(@"initial position is (.*)")]
        public void GivenInitialPositionIsN(string initialPosition)
        {
            // Arrange
            _positionParser = new PositionParser();
            _position = _positionParser.Parse(initialPosition);
        }
        
        [Given(@"the following command sequence (.*)")]
        public void GivenTheFollowingCommandSequenceRL(string commandSequence)
        {
            // Arrange
            _commandSequence = commandSequence;
            _commandSequencer = new SimpleCommandSequencer();
            _plateauConstraint = new SystemConstraint();
            _rover = new Rover(_position, _commandSequencer, _plateauConstraint);
        }

        [When(@"move command is given")]
        public void WhenMoveCommandIsGiven()
        {
            // Act
            _rover.Move(_commandSequence);
        }
        
        [Then(@"final position should be (.*)")]
        public void ThenFinalPositionShouldBeS(string finalPosition)
        {
            // Assert
            var position = _positionParser.Parse(finalPosition);
            _rover.CurrentPosition.Direction.Should().Be(position.Direction);
            _rover.CurrentPosition.X.Should().Be(position.X);
            _rover.CurrentPosition.Y.Should().Be(position.Y);
        }
    }
}
