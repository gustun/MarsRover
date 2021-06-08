using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Core.Enums;

namespace MarsRover.Core
{
    public class Rover
    {
        public Rover() { }

        public Rover(string currentPosition)
        {
            CurrentPosition = new Position(currentPosition);
        }

        public Position CurrentPosition { get; set; }

        public Position Move(string instructions, Plateau plateau)
        {
            var instructionList = instructions.ToList().Select(x => (EInstruction) Enum.ToObject(typeof(EInstruction), x));
            return Move(instructionList, plateau);
        }

        public Position Move(IEnumerable<EInstruction> instructions, Plateau plateau)
        {
            foreach (var instruction in instructions)
                ExecuteInstruction(plateau, instruction);

            return CurrentPosition;
        }

        private void ExecuteInstruction(Plateau plateau, EInstruction instruction)
        {
            switch (instruction)
            {
                case EInstruction.Right:
                    CurrentPosition.Direction = CurrentPosition.Direction.Right;
                    break;
                case EInstruction.Left:
                    CurrentPosition.Direction = CurrentPosition.Direction.Left;
                    break;
                case EInstruction.Move:
                    MoveForward(plateau);
                    break;
            }
        }

        private void MoveForward(Plateau plateau)
        {
            if (CurrentPosition.Direction.Key == Directions.NORTH.Key)
            {
                if (CurrentPosition.Yaxis + 1 > plateau.MaxYAxis) throw new Exception("you cannot move forward, you are at max y point");
                CurrentPosition.Yaxis++;
                return;
            }

            if (CurrentPosition.Direction.Key == Directions.EAST.Key)
            {
                if (CurrentPosition.Xaxis + 1 > plateau.MaxXAxis) throw new Exception("you cannot move forward, you are at max x point");
                CurrentPosition.Xaxis++;
                return;
            }

            if (CurrentPosition.Direction.Key == Directions.SOUTH.Key)
            {
                if (CurrentPosition.Yaxis - 1 < plateau.MinYAxis) throw new Exception("you cannot move forward, you are at min y point");
                CurrentPosition.Yaxis--;
                return;
            }

            if (CurrentPosition.Xaxis - 1 < plateau.MinXAxis) throw new Exception("you cannot move forward, you are at min x point");
            CurrentPosition.Xaxis--;
        }
    }
}