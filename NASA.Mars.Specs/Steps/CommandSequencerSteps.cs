using NASA.Mars.Contracts.Commands;
using NASA.Mars.Contracts.Sequencers;
using NASA.Mars.Impl.Sequencers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace NASA.Mars.Specs.Steps
{
    [Binding]
    public class CommandSequencerSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private ICommandSequencer _commandSequencer;
        private string _commandSequence;
        private List<ICommand> _commands;

        public CommandSequencerSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the command sequence of (.*)")]
        public void GivenTheCommandSequenceOfLL(string sequence)
        {
            // Arrange
            _commandSequence = sequence;
            _commandSequencer = new SimpleCommandSequencer();
        }
        
        [When(@"the command is sequenced")]
        public void WhenTheCommandIsSequenced()
        {
            // Act
            _commands = _commandSequencer.Sequence(_commandSequence);
        }
        
        [Then(@"the result should be L(.*) R(.*) L(.*)")]
        public void ThenTheResultShouldBeLRL(int p0, int p1, int p2)
        {
            // Assert
            _commands.Count.Should().Be(3);
            _commands[0].Units.Should().Be(p0);
            _commands[0].Direction.Should().Be("L");

            _commands[1].Units.Should().Be(p1);
            _commands[1].Direction.Should().Be("R");

            _commands[2].Units.Should().Be(p2);
            _commands[2].Direction.Should().Be("L");
        }
    }
}
