using NASA.Mars.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using NASA.Mars.Contracts.Sequencers;
using System.Text;
using NASA.Mars.Contracts.Constraints;
using NASA.Mars.Contracts.Commands;

namespace NASA.Mars.Impl
{
    public class Rover : IRover
    {
        private Stack<IPosition> _positions;

        public IConstraint Constraint { get; set; }
        public IPosition CurrentPosition { get; set; }
        public ICommandSequencer CommandSequencer { get; set; }

        public Rover(IPosition initialPosition, ICommandSequencer commandSequencer, IConstraint constraint)
        {
            CurrentPosition = initialPosition;
            CommandSequencer = commandSequencer;
            Constraint = constraint;

            _positions = new Stack<IPosition>();
            _positions.Push(initialPosition);
        }

        public virtual void Move(string commands)
        {
            Contract.Requires(!string.IsNullOrEmpty(commands));

            var commandSequence = CommandSequencer.Sequence(commands);
            
            foreach(var command in commandSequence)
            {
                Trundle(command);
            }
        }

        private void Trundle(ICommand command)
        {
            // TODO pull up to save cycles
            var allowedMovements = new Dictionary<string, (string Orientation, string Command, int X, int Y, string Direction)>();
            // pretty sure there's a bug in here somewhere TODO: complete specs
            allowedMovements.Add("NR", (Orientation: "N", Command: "R", X: CurrentPosition.X + command.Units, Y: CurrentPosition.Y, Direction: "E"));
            allowedMovements.Add("NL", (Orientation: "N", Command: "L", X: CurrentPosition.X - command.Units, Y: CurrentPosition.Y, Direction: "W"));
            allowedMovements.Add("SR", (Orientation: "S", Command: "R", X: CurrentPosition.X - command.Units, Y: CurrentPosition.Y, Direction: "W"));
            allowedMovements.Add("SL", (Orientation: "S", Command: "L", X: CurrentPosition.X + command.Units, Y: CurrentPosition.Y, Direction: "E"));
            allowedMovements.Add("ER", (Orientation: "E", Command: "R", X: CurrentPosition.X, Y: CurrentPosition.Y - command.Units, Direction: "S"));
            allowedMovements.Add("EL", (Orientation: "E", Command: "L", X: CurrentPosition.X, Y: CurrentPosition.Y + command.Units, Direction: "N"));
            allowedMovements.Add("WR", (Orientation: "W", Command: "R", X: CurrentPosition.X, Y: CurrentPosition.Y + command.Units, Direction: "N"));
            allowedMovements.Add("WL", (Orientation: "W", Command: "L", X: CurrentPosition.X, Y: CurrentPosition.Y - command.Units, Direction: "S"));

            var tuple = allowedMovements[$"{CurrentPosition.Direction}{command.Direction}"];
            SetPosition(tuple.X, tuple.Y, tuple.Direction);

            _positions.Push(CurrentPosition);
        }

        public virtual void SetPosition(int x, int y, string direction) // wrong logical level - should be at agent level
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(x <= Constraint.XMax);
            Contract.Requires(y <= Constraint.YMax);

            CurrentPosition = new Position(x, y, direction);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var position in _positions)
            {
                sb.AppendLine($"{position}");
            }

            return sb.ToString();
        }
    }
}
