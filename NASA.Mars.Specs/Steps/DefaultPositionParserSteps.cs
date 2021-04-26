using NASA.Mars.Contracts;
using NASA.Mars.Contracts.Parsers;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using NASA.Mars.Impl.Parsers;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;
using System.Linq;

namespace NASA.Mars.Specs.Steps
{
    [Binding]
    public class DefaultPositionParserSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private IPositionParser _positionParser;
        private IPosition _position;
        private string _positionSequence;

        public DefaultPositionParserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an initial sequence of")]
        public void GivenAnInitialSequenceOf(Table table)
        {
            // Arrange
            _positionParser = new PositionParser();
            _positionSequence = table.Rows[0]["Sequence"];
        }
        
        [When(@"the parse command is given")]
        public void WhenTheParseCommandIsGiven()
        {
            // Act
            _position = _positionParser.Parse(_positionSequence);
        }
        
        [Then(@"result should be X=(.*), Y=(.*) and Direction=""(.*)""")]
        public void ThenResultShouldBeXYAndDirection(int p0, int p1, string p2)
        {
            // Assert
            _position.X.Should().Be(p0);
            _position.Y.Should().Be(p1);
            _position.Direction.Should().Be(p2);
        }
    }
}
