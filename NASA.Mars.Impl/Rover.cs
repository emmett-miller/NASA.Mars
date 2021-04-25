using NASA.Mars.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace NASA.Mars.Impl
{
    public class Rover : IRover
    {
        private Stack<IPosition> _positions;
        private int _units;

        public IConstraint Constraint { get; set; }
        public IPosition CurrentPosition { get; set; }
        public ICommandSequencer CommandSequencer { get; set; }

        public Dictionary<string, Dictionary<string, Action>> _allowedMovements { get; set; }

        public Rover(IPosition initialPosition, ICommandSequencer commandSequencer, IConstraint constraint)
        {
            CurrentPosition = initialPosition;
            CommandSequencer = commandSequencer;
            Constraint = constraint;

            //_allowedMovements = new Dictionary<string, Dictionary<string, Action>>();
            //var directionalMovements = new Dictionary<string, Action>();
            //directionalMovements.Add("E", () => SetPosition(CurrentPosition.X + _units, CurrentPosition.Y, "E"));
            //directionalMovements.Add("E", () => SetPosition(CurrentPosition.X - _units, CurrentPosition.Y, "W"));
            //directionalMovements.Add("E", () => SetPosition(CurrentPosition.X + _units, CurrentPosition.Y, "E"));
            //directionalMovements.Add("E", () => SetPosition(CurrentPosition.X + _units, CurrentPosition.Y, "E"));

            // _allowedMovements.Add("N", )

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
            var t1 = (Orientation: "N", Command: "R", X: CurrentPosition.X + command.Units, Y: CurrentPosition.Y, Direction: "E");
            var t2 = (Orientation: "N", Command: "L", X: CurrentPosition.X - command.Units, Y: CurrentPosition.Y, Direction: "W");          
            var t3 = (Orientation: "S", Command: "R", X: CurrentPosition.X - command.Units, Y: CurrentPosition.Y, Direction: "W");
            var t4 = (Orientation: "S", Command: "L", X: CurrentPosition.X + command.Units, Y: CurrentPosition.Y, Direction: "E");
            var t5 = (Orientation: "E", Command: "R", X: CurrentPosition.X, Y: CurrentPosition.Y - command.Units, Direction: "S");
            var t6 = (Orientation: "E", Command: "L", X: CurrentPosition.X, Y: CurrentPosition.Y + command.Units, Direction: "N");
            var t7 = (Orientation: "W", Command: "R", X: CurrentPosition.X, Y: CurrentPosition.Y + command.Units, Direction: "N");
            var t8 = (Orientation: "W", Command: "L", X: CurrentPosition.X, Y: CurrentPosition.Y - command.Units, Direction: "S");

            allowedMovements.Add("NR", t1);
            allowedMovements.Add("NL", t2);
            allowedMovements.Add("SR", t3);
            allowedMovements.Add("SL", t4);
            allowedMovements.Add("ER", t5);
            allowedMovements.Add("EL", t6);
            allowedMovements.Add("WR", t7);
            allowedMovements.Add("WL", t8);

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
