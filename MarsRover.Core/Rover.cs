using System;
using System.Collections.Generic;
using MarsRover.Core.Enums;

namespace MarsRover.Core
{
    public class Rover
    {
        public Position CurrentPosition { get; set; }

        public Position Move(List<EInstruction> instructions, Plateau plateau)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case EInstruction.R:
                        TurnRight();
                        break;
                    case EInstruction.L:
                        TurnLeft();
                        break;
                    case EInstruction.M:
                        MoveForward(plateau);
                        break;
                }
            }
            
            return CurrentPosition;
        }

        private void TurnLeft()
        {
            switch (CurrentPosition.Direction)
            {
                case EDirection.N:
                    CurrentPosition.Direction = EDirection.W;
                    break;
                case EDirection.E:
                    CurrentPosition.Direction = EDirection.N;
                    break;
                case EDirection.S:
                    CurrentPosition.Direction = EDirection.E;
                    break;
                case EDirection.W:
                    CurrentPosition.Direction = EDirection.S;
                    break;
            }
        }
        
        private void TurnRight()
        {
            switch (CurrentPosition.Direction)
            {
                case EDirection.N:
                    CurrentPosition.Direction = EDirection.E;
                    break;
                case EDirection.E:
                    CurrentPosition.Direction = EDirection.S;
                    break;
                case EDirection.S:
                    CurrentPosition.Direction = EDirection.W;
                    break;
                case EDirection.W:
                    CurrentPosition.Direction = EDirection.N;
                    break;
            }
        }
        
        private void MoveForward(Plateau plateau)
        {
            switch (CurrentPosition.Direction)
            {
                case EDirection.N:
                    CurrentPosition.Yaxis++;
                    break;
                case EDirection.E:
                    CurrentPosition.Xaxis++;
                    break;
                case EDirection.S:
                    CurrentPosition.Yaxis--;
                    break;
                case EDirection.W:
                    CurrentPosition.Xaxis--;
                    break;
            }
        }
    }
}