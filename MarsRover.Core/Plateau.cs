using System;

namespace MarsRover.Core
{
    public class Plateau
    {
        public Plateau(string input)
        {
            var coordinates = input.Split(' ');
            if (coordinates.Length != 2) throw new Exception("invalid plateau coordinates");
            var xParseResult = int.TryParse(coordinates[0], out var xaxis);
            var yParseResult = int.TryParse(coordinates[1], out var yaxis);
            var inputsAreInvalid = !(xParseResult && yParseResult);
            if (inputsAreInvalid) throw new Exception("invalid plateau coordinates");
            MaxXAxis = xaxis;
            MaxYAxis = yaxis;
        }

        public Plateau(int maxXAxis, int maxYAxis)
        {
            MaxXAxis = maxXAxis;
            MaxYAxis = maxYAxis;
        }

        public int MaxXAxis { get; }
        public int MaxYAxis { get; }
        public int MinXAxis => 0;
        public int MinYAxis => 0;
    }
}