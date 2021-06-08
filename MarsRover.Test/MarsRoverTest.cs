using System.Collections.Generic;
using MarsRover.Core;
using MarsRover.Core.Enums;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        [Test]
        public void Case1()
        {
            // Given
            var currentPosition = new Position { Xaxis = 1, Yaxis = 2, Direction = EDirection.N };
            var rover = new Rover { CurrentPosition = currentPosition };
            var instructions = new List<EInstruction>
            {
                EInstruction.L,
                EInstruction.M,
                EInstruction.L,
                EInstruction.M,
                EInstruction.L,
                EInstruction.M,
                EInstruction.L,
                EInstruction.M,
                EInstruction.M
            };
            var plateau = new Plateau(5, 5);

            // When
            var result = rover.Move(instructions, plateau);
            
            // Then
            Assert.AreEqual(1, result.Xaxis);
            Assert.AreEqual(3, result.Yaxis);
            Assert.AreEqual(EDirection.N, result.Direction);
        }
        
        [Test]
        public void Case2()
        {
            // Given
            var currentPosition = new Position { Xaxis = 3, Yaxis = 3, Direction = EDirection.E };
            var rover = new Rover { CurrentPosition = currentPosition };
            var instructions = new List<EInstruction>
            {
                EInstruction.M,
                EInstruction.M,
                EInstruction.R,
                EInstruction.M,
                EInstruction.M,
                EInstruction.R,
                EInstruction.M,
                EInstruction.R,
                EInstruction.R,
                EInstruction.M
            };
            var plateau = new Plateau(5, 5);

            // When
            var result = rover.Move(instructions, plateau);
            
            // Then
            Assert.AreEqual(5, result.Xaxis);
            Assert.AreEqual(1, result.Yaxis);
            Assert.AreEqual(EDirection.E, result.Direction);
        }
    }
}