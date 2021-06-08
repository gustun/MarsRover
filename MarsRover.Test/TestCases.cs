using System;
using System.Collections.Generic;
using MarsRover.Core;
using MarsRover.Core.Enums;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class TestCases
    {
        [Test]
        public void Case1()
        {
            // Given
            var currentPosition = new Position { Xaxis = 1, Yaxis = 2, Direction = Directions.NORTH };
            var rover = new Rover { CurrentPosition = currentPosition };
            var instructions = new List<EInstruction>
            {
                EInstruction.Left,
                EInstruction.Move,
                EInstruction.Left,
                EInstruction.Move,
                EInstruction.Left,
                EInstruction.Move,
                EInstruction.Left,
                EInstruction.Move,
                EInstruction.Move
            };
            var plateau = new Plateau(5, 5);

            // When
            var result = rover.Move(instructions, plateau);
            
            // Then
            Assert.AreEqual(1, result.Xaxis);
            Assert.AreEqual(3, result.Yaxis);
            Assert.AreEqual(Directions.NORTH.Key, result.Direction.Key);
        }
        
        [Test]
        public void Case2()
        {
            // Given
            var currentPosition = new Position { Xaxis = 3, Yaxis = 3, Direction = Directions.EAST };
            var rover = new Rover { CurrentPosition = currentPosition };
            var instructions = new List<EInstruction>
            {
                EInstruction.Move,
                EInstruction.Move,
                EInstruction.Right,
                EInstruction.Move,
                EInstruction.Move,
                EInstruction.Right,
                EInstruction.Move,
                EInstruction.Right,
                EInstruction.Right,
                EInstruction.Move
            };
            var plateau = new Plateau(5, 5);

            // When
            var result = rover.Move(instructions, plateau);
            
            // Then
            Assert.AreEqual(5, result.Xaxis);
            Assert.AreEqual(1, result.Yaxis);
            Assert.AreEqual(Directions.EAST.Key, result.Direction.Key);
        }
        
        [Test]
        public void MaximumPointCase()
        {
            // Given
            var currentPosition = new Position { Xaxis = 5, Yaxis = 5, Direction = Directions.NORTH };
            var rover = new Rover { CurrentPosition = currentPosition };
            var instructions = new List<EInstruction> { EInstruction.Move };
            var instructions2 = new List<EInstruction> { EInstruction.Right, EInstruction.Move };
            var plateau = new Plateau(5, 5);

            // When
            Exception ex1 = Assert.Throws<Exception>(delegate { rover.Move(instructions, plateau); });
            Exception ex2 = Assert.Throws<Exception>(delegate { rover.Move(instructions2, plateau); });
            
            // Then
            Assert.AreEqual(ex1.Message, "you cannot move forward, you are at max y point");
            Assert.AreEqual(ex2.Message, "you cannot move forward, you are at max x point");
        }
        
        [Test]
        public void MinimumPointCase()
        {
            // Given
            var currentPosition = new Position { Xaxis = 0, Yaxis = 0, Direction = Directions.SOUTH };
            var rover = new Rover { CurrentPosition = currentPosition };
            var instructions = new List<EInstruction> { EInstruction.Move };
            var instructions2 = new List<EInstruction> { EInstruction.Right, EInstruction.Move };
            var plateau = new Plateau(5, 5);

            // When
            Exception ex1 = Assert.Throws<Exception>(delegate { rover.Move(instructions, plateau); });
            Exception ex2 = Assert.Throws<Exception>(delegate { rover.Move(instructions2, plateau); });
            
            // Then
            Assert.AreEqual(ex1.Message, "you cannot move forward, you are at min y point");
            Assert.AreEqual(ex2.Message, "you cannot move forward, you are at min x point");
        }

        [Test]
        public void MainCase()
        {
            // Given
            var plateauInput = "5 5";
            var rover1Location = "1 2 N";
            var rover1Instructions = "LMLMLMLMM";
            var rover2Location = "3 3 E";
            var rover2Instructions = "MMRMMRMRRM";

            var plateau = new Plateau(plateauInput);
            var rover1 = new Rover(rover1Location);
            var rover2 = new Rover(rover2Location);

            // When
            var rover1FinalLocation = rover1.Move(rover1Instructions, plateau);
            var rover2FinalLocation = rover2.Move(rover2Instructions, plateau);
            
            // Then
            Assert.AreEqual(1, rover1FinalLocation.Xaxis);
            Assert.AreEqual(3, rover1FinalLocation.Yaxis);
            Assert.AreEqual(Directions.NORTH.Key, rover1FinalLocation.Direction.Key);
            
            Assert.AreEqual(5, rover2FinalLocation.Xaxis);
            Assert.AreEqual(1, rover2FinalLocation.Yaxis);
            Assert.AreEqual(Directions.EAST.Key, rover2FinalLocation.Direction.Key);
        }
    }
}